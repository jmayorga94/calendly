﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calendly.Application.Models.Authentication
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
