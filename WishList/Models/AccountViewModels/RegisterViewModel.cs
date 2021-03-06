﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishList.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [StringLength(100,MinimumLength =8)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare("Password",ErrorMessage ="The Password field and Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
