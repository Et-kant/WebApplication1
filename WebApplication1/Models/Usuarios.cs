using System.ComponentModel.DataAnnotations;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Direcion de correo no valida")]
        public string correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string hashPassword { get; set; }
    }
}
