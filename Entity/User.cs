﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi2Tarea.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}