using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Models.ApiModels
{
    public class CreateTodoModel
    {
        [Required]
        public string Text { get; set; }
    }
}
