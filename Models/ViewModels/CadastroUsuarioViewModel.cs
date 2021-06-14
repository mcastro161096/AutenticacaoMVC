using System.ComponentModel.DataAnnotations;

namespace AutenticacaoMVC.Models.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage ="Informe seu nome")]
        [MaxLength(100, ErrorMessage ="O nome deve ter até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(100, ErrorMessage = "O login deve ter até 100 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirme a senha")]
        [Compare(nameof(Senha), ErrorMessage ="A senha e a confirmação não estão iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}