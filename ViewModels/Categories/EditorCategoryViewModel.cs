using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Categories;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "Informe o Nome")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Esse campo deve conter no minimo 3 caracteres e no maximo 80!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "informe o Slug")]
    public string Slug { get; set; }
}
