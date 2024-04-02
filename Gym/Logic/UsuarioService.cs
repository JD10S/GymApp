using Gym.Data;
using Gym.Entity;



namespace Gym.Logic
{
    public class UsuarioService
    {
        private readonly GenericRepository<Usuario> _usuarioRepository;
        private readonly CredentialService _credencialService;
    
        public UsuarioService()
        {
            _usuarioRepository = new GenericRepository<Usuario>();
            _credencialService = new CredentialService();
        }

        public Response<IEnumerable<Usuario>> GetAllUsuarios()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll();
                return new Response<IEnumerable<Usuario>>(true, "Operación exitosa", usuarios);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Usuario>>(false, ex.Message, Enumerable.Empty<Usuario>().AsQueryable());
            }
        }

        public Response<Usuario> GetUsuarioById(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario != null)
                    return new Response<Usuario>(true, "Operación exitosa", usuario);
                else
                    return new Response<Usuario>(false, "Usuario no encontrado", new Usuario());
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, ex.Message, new Usuario());
            }
        }

        public Response<Usuario> GetUsuarioByCredencial(string credencial)
        {
            try
            {
                Dictionary<string, object> conditions = new Dictionary<string, object>();
                conditions.Add("Credencial", credencial);
                var usuario = _usuarioRepository.GetByCondition(conditions).FirstOrDefault();
                if (usuario != null)
                    return new Response<Usuario>(true, "Operación exitosa", usuario);
                else
                    return new Response<Usuario>(false, "Usuario no encontrado", new Usuario());
            }
            catch (Exception ex)
            {
                return new Response<Usuario>(false, ex.Message, new Usuario());
            }
        }

        public Response<bool> InsertUsuario(Usuario usuario)
        {
            try
            {

                Dictionary<string, object> conditions = new Dictionary<string, object>();
                conditions.Add("Identificacion", usuario.Identificacion);
                var findUser = _usuarioRepository.GetByCondition(conditions).FirstOrDefault();
                if (findUser == null)
                {
                    _usuarioRepository.Insert(usuario);
                    _usuarioRepository.Save();
                    return new Response<bool>(true, "Operación exitosa", true);
                }
                return new Response<bool>(false, "Usuario con identificacion ya registrada", false);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        public Response<bool> UpdatePagoUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario != null)
                {
                    usuario.FechaRegistro = DateTime.Now;

                    _usuarioRepository.Update(usuario);
                    _usuarioRepository.Save();
                    return new Response<bool>(true, "Operación exitosa", true);
                }
                return new Response<bool>(false, "Usuario no encontrado", false);

            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        public Response<bool> UpdateUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Update(usuario);
                _usuarioRepository.Save();
                return new Response<bool>(true, "Operación exitosa", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        
        public Response<bool> EliminarUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario != null)
                {
                    var responseCredenciales = _credencialService.EliminarCredenciales(usuario.Credencial);

                    if (responseCredenciales.Success)
                    {
                        _usuarioRepository.Delete(id);
                        _usuarioRepository.Save();

                        return new Response<bool>(true, "Usuario y credenciales eliminados exitosamente", true);
                    }
                    else
                    {
                        return new Response<bool>(false, "Error al eliminar credenciales", false);
                    }
                }

                return new Response<bool>(false, "Usuario no encontrado", false);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }
        public Response<bool> ActualizarUsuario(Usuario usuario)
        {
            try
            {
                // Buscar el usuario existente en la base de datos
                var usuarioExistente = _usuarioRepository.GetById(usuario.Id);

                // Verificar si el usuario existe
                if (usuarioExistente != null)
                {
                    // Actualizar las propiedades del usuario existente con las del nuevo usuario
                    usuarioExistente.Nombre = usuario.Nombre;
                    usuarioExistente.Apellido = usuario.Apellido;
                    usuarioExistente.Identificacion = usuario.Identificacion;

                    // Otros campos que necesitas actualizar...

                    // Guardar los cambios en la base de datos
                    _usuarioRepository.Update(usuarioExistente);
                    _usuarioRepository.Save();

                    return new Response<bool>(true, "Usuario actualizado exitosamente", true);
                }
                else
                {
                    return new Response<bool>(false, "Usuario no encontrado", false);
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

    }
}
//public Response<bool> DeleteUsuario(int id)
//{
//    try
//    {
//        _usuarioRepository.Delete(Usuario);
//        _usuarioRepository.Save();
//        return new Response<bool>(true, "Operación exitosa", true);
//    }
//    catch (Exception ex)
//    {
//        return new Response<bool>(false, ex.Message, false);
//    }
//}
