using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Indique si el usuario es administrador o no.")]
        public bool IsAdmin { get; set; }
    }
}
