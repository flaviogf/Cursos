﻿using System.ComponentModel.DataAnnotations;

namespace WithoutIdentity.Mvc.ViewModels.ChangePassword
{
    public class ChangePasswordEditViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        [StringLength(100, ErrorMessage = "The field {0} must has min {2} and max {1} characters.", MinimumLength = 8)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
