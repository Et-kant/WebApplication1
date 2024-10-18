using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Access : Controller
    {
        //recibe las solicitudes del usuario y luego interactua con el modeolo y devolver respuesta
        //se maneja un poco la logica para devolver al usuario o actualizar las vistas

        private readonly String cadenaConection = "Server = localhost; Database=MiAplicacion;User=root;Password=1234";
       

        public IActionResult Login()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(String email, String password)
        {   
            if (ModelState.IsValid)
            {
                String hashPassword = HashContraseña(password);

                using(MySqlConnection con = new MySqlConnection(cadenaConection))
                {
                    try
                    {
                        con.Open();
                        var consulta = "INSERT INTO Usuarios (Email, Contraseña) VALUES (@Email, @Contraseña)";
                        using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                        {
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Contraseña",  password);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine(ex);
                    }
                }

                return RedirectToAction("Login");
            }


            return View();
        }

        private string HashContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(contraseña);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private bool VerificarContraseña(string hashGuardado, string contraseñaIngresada)
        {
            string hashIngresado = HashContraseña(contraseñaIngresada);
            return hashGuardado == hashIngresado;
        }

    }




}
