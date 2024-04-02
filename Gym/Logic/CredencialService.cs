using Gym.Data;
using Gym.Entity;


namespace Gym.Logic
{
    public class CredentialService
    {
        private readonly GenericRepository<Credencial> _credencialRepository;
        private readonly GenericRepository<Usuario> _usuarioRepository;

        public CredentialService()
        {
            _credencialRepository = new GenericRepository<Credencial>();
            _usuarioRepository = new GenericRepository<Usuario>();
        }

        public Response<bool> EliminarCredenciales(string nombreUsuario)
        {
            try
            {
                Dictionary<string, object> conditions = new Dictionary<string, object>();
                conditions.Add("NombreUsuario", nombreUsuario);               
                var credencialEntity = _credencialRepository.GetByCondition(conditions).FirstOrDefault();
                
                if (credencialEntity != null)
                {
                    _credencialRepository.Delete2(credencialEntity.NombreUsuario);
                    _credencialRepository.Save();
                    return new Response<bool>(true, "Usuario y credenciales eliminados exitosamente", true);
                }
                else
                {
                    return new Response<bool>(false, "Credenciales no encontradas", false);
                }

                
            }
            catch (Exception ex)
            {
                // Si se produce una excepción, devolver una respuesta con éxito falso y el mensaje de error
                return new Response<bool>(false, ex.Message, false);
            }

        }


        public Response<bool> RegisterUsuario(string username, string password)
        {
            try
            {
                Dictionary<string, object> conditions = new Dictionary<string, object>();
                conditions.Add("NombreUsuario", username);
                var existingUser = _credencialRepository.GetByCondition(conditions).FirstOrDefault();
                if (existingUser != null)
                    return new Response<bool>(false, "El nombre de usuario ya existe", false);

                var newUser = new Credencial
                {
                    NombreUsuario = username,
                    Contraseña = password
                };

                _credencialRepository.Insert(newUser);
                _credencialRepository.Save();
                return new Response<bool>(true, "Usuario registrado exitosamente", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        public Response<bool> ValidateUsuario(string username)
    {
        try
        {
            Dictionary<string, object> conditions = new Dictionary<string, object>();
            conditions.Add("NombreUsuario", username);
            var existingUser = _credencialRepository.GetByCondition(conditions).FirstOrDefault();
            if (existingUser != null)
                return new Response<bool>(true, "Usuario encontrado", true);
            else
                return new Response<bool>(false, "Usuario no encontrado", false);
        }
        catch (Exception ex)
        {
            return new Response<bool>(false, ex.Message, false);
        }
    }

    public Response<Credencial> Login(string username, string password)
    {
        try
        {

                Dictionary<string, object> conditions = new Dictionary<string, object>();
                conditions.Add("NombreUsuario", username);
                conditions.Add("Contraseña", password);
                var existingUser = _credencialRepository.GetByCondition(conditions).FirstOrDefault();
                if (existingUser != null)
                    return new Response<Credencial>(true, "Inicio de sesión exitoso", existingUser);
                else
                    return new Response<Credencial>(false, "Credenciales inválidas", new Credencial());
            }
        catch (Exception ex)
        {
            return new Response<Credencial>(false, ex.Message, new Credencial());
            }
    }
}
}
