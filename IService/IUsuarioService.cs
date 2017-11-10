using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi2Tarea.Entity;
using webapi2Tarea.Models;

namespace webapi2Tarea.IService
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> findAll();
        Usuario findUserByUserModel(UserModel userModel);
       // string addUser(Usuario usuario);
        string RemoveUserByRut(int rut);
        Usuario findUserByRut(int rutEmpleado);


    }
}
