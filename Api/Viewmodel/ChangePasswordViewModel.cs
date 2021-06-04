using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class ChangePasswordViewModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }
    }
}
