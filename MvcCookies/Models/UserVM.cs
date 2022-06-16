﻿using System.ComponentModel.DataAnnotations;

namespace MvcCookies.Models
{
    public class UserVM
    {
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
