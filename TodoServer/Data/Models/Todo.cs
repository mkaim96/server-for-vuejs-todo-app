﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Data.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
        public ApplicationUser User { get; set; }
    }
}
