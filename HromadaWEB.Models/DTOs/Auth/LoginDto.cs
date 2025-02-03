﻿using System.ComponentModel.DataAnnotations;

public class LoginDto
{
    [Required(ErrorMessage = "Email обов'язковий.")]
    [EmailAddress(ErrorMessage = "Невірний формат email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обов'язковий.")]
    public string Password { get; set; }
}
