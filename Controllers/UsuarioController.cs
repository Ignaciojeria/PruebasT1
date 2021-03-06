﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using webapi2Tarea.IService;
using webapi2Tarea.Models;

namespace webapi2Tarea.Controllers
{
    public class UsuarioController : ApiController
    {
        private IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_service.findAll());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserModel userModel)
        {//pista para los ?? http://itknowledgeexchange.techtarget.com/itanswers/ebcdic-to-ascii-conversion-c-sharp/


            //HashBytes('MD5', @PASSW)
            string HashBytes = MD5Hash(userModel.contrasena);
            byte[] asciiBytes = Encoding.ASCII.GetBytes(HashBytes);

      

           // CONVERT(NVARCHAR(45), HashBytes('MD5', @PASSW)
           //string convert= Convert.ToBase64String(asciiBytes);

            // cast(@PASSW + LOWER(CONVERT(NVARCHAR(45), HashBytes('MD5', @PASSW), 2)
            byte[] asciiBytesB = Encoding.ASCII.GetBytes(userModel.contrasena+HashBytes);
           //string sha1 = GetSHA1HashData(userModel.contrasena + HashBytes);

          


            //HashBytes('SHA1',cast(@PASSW+LOWER(CONVERT(NVARCHAR(45),HashBytes('MD5',@PASSW),2)
            HashAlgorithm algorithm = SHA1.Create();
             byte[] sha1=  algorithm.ComputeHash(asciiBytesB);

            //cast(HashBytes('SHA1',cast(@PASSW+LOWER(CONVERT(NVARCHAR(45),HashBytes('MD5',@PASSW),2))
             string finalCast = Encoding.ASCII.GetString(sha1);

            //
            //    if (sha1.Equals(_service.findUserByUserModel(userModel).contrasena)) return Ok(true);
            //utf8 Bytes to string 
            // userModel.contrasena = finalCast;
            //  if (finalCast.Equals( _service.findUserByUserModel(userModel).contrasena)) return Ok(true);

            //  return Ok(_service.findUserByUserModel(userModel).contrasena);
             return Ok(sha1);

        }


        public string ASCIITOHex(string ascii)

        {

            StringBuilder sb = new StringBuilder();

            byte[] inputBytes = Encoding.UTF8.GetBytes(ascii);

            foreach (byte b in inputBytes)

            {

                sb.Append(string.Format("{0:x2}", b));

            }

            return sb.ToString();

        }


        public byte[] Encode(string text)
        {
            return Encoding.GetEncoding(1252).GetBytes(text);
        }





        private static string MD5Hash(string input)
        {
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

        public static string ASCIIToDecimal(string str)
        {
            string dec = string.Empty;

            for (int i = 0; i < str.Length; ++i)
            {
                string cDec = ((byte)str[i]).ToString();

                if (cDec.Length < 3)
                    cDec = cDec.PadLeft(3, '0');

                dec += cDec;
            }

            return dec;
        }

        public static byte[] ConvertAsciiToEbcdic(byte[] asciiData)
        {
            // Create two different encodings. 
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037"); //Retutn Ebcdic Data 
            return Encoding.Convert(ascii, ebcdic, asciiData);
        }


        public static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }


    }
}
