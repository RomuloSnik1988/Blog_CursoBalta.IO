using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Account;

public class UploadImageViewModel
{
    [Required(ErrorMessage ="Imagem inválida")]
    public string Base64Image { get; set; }
}
