using System.ComponentModel.DataAnnotations;

namespace AutenticacaoMVC.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(100, ErrorMessage = "O login deve ter até 100 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}