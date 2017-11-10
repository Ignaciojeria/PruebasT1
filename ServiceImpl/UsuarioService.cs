using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using webapi2Tarea.Entity;
using webapi2Tarea.IService;
using webapi2Tarea.Models;
using webapi2Tarea.Repository;

namespace webapi2Tarea.ServiceImpl
{
    public class UsuarioService :IUsuarioService
    {
        SGR4Context db = new SGR4Context();




        public IEnumerable<Usuario> findAll()
        {
            return db.Usuario;
        }


        public Usuario findUserByRut(int rutEmpleado)
        {
            try {
            return db.Usuario.First(i=> i.rutEmpleado==rutEmpleado);
            }
            catch
            {
                return null;
            }
        }

        public Usuario findUserByUserModel(UserModel userModel)
        {
            //cast(HashBytes('SHA1',cast(@PASSW+LOWER(CONVERT(NVARCHAR(45),HashBytes('MD5',@PASSW),2)) as varchar(100)))
            try
            {

                //  var bytes = new UTF32Encoding().GetBytes(userModel.contrasena.ToLower());
                // var hashBytes =new SHA1CryptoServiceProvider().ComputeHash(new MD5CryptoServiceProvider().ComputeHash(bytes));
                Usuario usuario = db.Usuario.First(i => i.usuario == userModel.usuario);
             
              //  usuario.contrasena = GetSHA1HashData(userModel.contrasena + (MD5Hash(userModel.contrasena)).ToLower());

                // usuario.contrasena = System.Text.Encoding.Unicode.GetBytes(usuario.contrasena);
                return usuario;
            }
            catch{
                return null;
            }
        }

   


        public string RemoveUserByRut(int rut)
        {
            throw new NotImplementedException();
        }


        public static string MD5Hash(string input)
        {
            input=input.ToLower();
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }



        /*
             public string addUser(Usuario usuario)
             {

                 if (findUserByUserModel(new UserModel() { correo = usuario.correo, contrasena = usuario.contrasena }) != null)
                     return "El usuario ya existe";*/
        // db.Usuario.Add(usuario);
        //        db.SaveChanges();
        //       return "El usuario: " + usuario.usuario + " con correo: " + usuario.correo + " se ha creado satisfactoriamente"; 

        //db.Entry(usuario).State = EntityState.Added;
        //db.SaveChanges();
        //       } 

        /*

        public string RemoveUserByRut(int rut)
        {
            if (findUserByRut(rut)==null) return "El usuario no existe";

            Usuario usuario = db.Usuario.First(i => i.rutEmpleado == rut);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return "El usuario con correo "+ usuario.correo+ ": ha sido satisfactoriamente eliminado";
        }
        */




        /*
       public Usuario findByUserModel(UserModel userModel)
       {
           try {
           return userContext.findByUserModel(userModel);
           }
           catch
           {
               return null;
           }
       }

       //Usuario hardCodeado
       public Usuario GetUserByCredentials(string email, string password)
       {
           if (email.Equals("admin") && password.Equals("admin"))
               return new Usuario() { Id = "1", Email = "email@domain.com", Password = "password", Name = "Ole Petter Dahlmann" };
           else return null;
       }*/

    }
}