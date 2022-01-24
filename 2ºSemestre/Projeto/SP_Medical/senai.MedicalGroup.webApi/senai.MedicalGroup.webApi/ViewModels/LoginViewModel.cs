
using System.ComponentModel.DataAnnotations;


namespace senai.MedicalGroup.webApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = " e-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "senha do usuário!")]
        public string Senha { get; set; }
    }
}
