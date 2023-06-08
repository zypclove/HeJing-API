﻿using System.ComponentModel.DataAnnotations;
using IdentityServer.Shared.Configuration.Configuration.Identity;

namespace IdentityServer.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
