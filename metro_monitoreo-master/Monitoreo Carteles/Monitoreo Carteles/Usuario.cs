﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoreo_Carteles
{
    class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
        //Other properties, methods, events...
    }
}
