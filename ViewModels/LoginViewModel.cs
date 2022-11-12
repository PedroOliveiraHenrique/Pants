using System.ComponentModel.DataAnnotations;
namespace NetPants.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Usuário")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
