using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Gym.Data
{
    public class GenericRepository<TEntity> where TEntity : class 
    {
        private readonly string _connectionString;

        public GenericRepository()
        {
            _connectionString = "Server=localhost;Database=DbGym;Integrated Security=True; Trusted_Connection = True; MultipleActiveResultSets = true";
        }

        private void ExecuteNonQuery(string query, object parameters = null, bool omit = false)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        var properties = parameters.GetType().GetProperties(); 
                        foreach (var prop in properties)
                        {
                            if (omit)
                            {
                                if (prop.Name != "Id")
                                {
                                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters));
                                }
                            }
                            else
                            {
                                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters));
                            }

                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        private string GetPrimaryKeyName(string tableName)
        {
            string query = $@"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
        AND TABLE_NAME = '{tableName}'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var primaryKey = command.ExecuteScalar();
                    if (primaryKey != null)
                    {
                        return primaryKey.ToString();
                    }
                    else
                    {
                        throw new InvalidOperationException("Primary key not found for table.");
                    }
                }
            }
        }


        private IEnumerable<string> GetPropertyNames(TEntity entity, string omit = "")
        {
            
            return entity.GetType().GetProperties().Where(p => p.Name != omit) // Omitir la propiedad "Id"
                .Select(p => p.Name); 
        }

        private TEntity MapObject(IDataRecord reader)
        {
            var obj = Activator.CreateInstance<TEntity>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(reader.GetName(i));
                if (propertyInfo != null && reader[i] != DBNull.Value)
                {
                    propertyInfo.SetValue(obj, reader[i]);
                }
            }
            return obj;
        }


        public IEnumerable<TEntity> GetAll()
        {
            string tableName = typeof(TEntity).Name;
            string query = $"SELECT * FROM {tableName}";
            return ExecuteQuery(query);
        }
        private IEnumerable<TEntity> ExecuteQuery(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        var properties = parameters.GetType().GetProperties();
                        foreach (var prop in properties)
                        {
                            command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters));
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        var list = new List<TEntity>();
                        while (reader.Read())
                        {
                            var item = MapObject(reader);
                            list.Add(item);
                        }
                        return list;
                    }
                }
            }
        }

        public IEnumerable<TEntity> GetByCondition(Dictionary<string, object> conditions)
        {
            if (conditions == null || conditions.Count == 0)
            {
                throw new ArgumentException("No conditions provided.");
            }

            string tableName = typeof(TEntity).Name;
            string query = $"SELECT * FROM {tableName} WHERE ";

            string whereClause = string.Join(" AND ", conditions.Select(c => $"{c.Key} = @{c.Key}"));
            query += whereClause;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    foreach (var condition in conditions)
                    {
                        command.Parameters.AddWithValue($"@{condition.Key}", condition.Value);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        var list = new List<TEntity>();
                        while (reader.Read())
                        {
                            var item = MapObject(reader);
                            list.Add(item);
                        }
                        return list;
                    }
                }
            }
        }

        public TEntity GetById(object id)
        {
            string tableName = typeof(TEntity).Name;
            string primaryKey = GetPrimaryKeyName(tableName);
            string query = $"SELECT * FROM {tableName} WHERE {primaryKey} = @Id";

            return ExecuteQuerySingle(query, new { Id = id });
        }

        private TEntity ExecuteQuerySingle(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        var properties = parameters.GetType().GetProperties();
                        foreach (var prop in properties)
                        {
                            command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters));
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapObject(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void Insert(TEntity entity)
        {
            string tableName = typeof(TEntity).Name;
            string columns = string.Join(", ", GetPropertyNames(entity, "Id"));
            string values = string.Join(", ", GetPropertyNames(entity, "Id").Select(p => $"@{p}"));
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            ExecuteNonQuery(query, entity, true);
        }

        public void Update(TEntity entity)
        {
            string tableName = typeof(TEntity).Name;
            string primaryKey = GetPrimaryKeyName(tableName);
            string setClause = string.Join(", ", GetPropertyNames(entity)
                .Where(p => p != primaryKey)
                .Select(p => $"{p} = @{p}"));
            string query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKey} = @{primaryKey}";

            ExecuteNonQuery(query, entity);
        }

        public void Delete(int entity)
        {
            string tableName = typeof(TEntity).Name;
            string primaryKey = GetPrimaryKeyName(tableName);
            string query = $"DELETE FROM {tableName} WHERE {primaryKey} = @Id";

            ExecuteNonQuery(query, new { Id = entity });
        }
        public void Delete2(string entity)
        {
            string tableName = typeof(TEntity).Name;
            string primaryKey = GetPrimaryKeyName(tableName);
            string query = $"DELETE FROM {tableName} WHERE {primaryKey} = @NombreUsuario";

            ExecuteNonQuery(query, new { NombreUsuario = entity });
        }
        public void Save()
        {
        }
    }
}
