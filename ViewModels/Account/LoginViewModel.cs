﻿using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; }
}
