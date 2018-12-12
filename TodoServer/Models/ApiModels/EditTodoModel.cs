using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Models.ApiModels
{
    public class EditTodoModel
    {
        [Required]
        public int TodoId { get; set; }

        [Required]
        public string NewTodoText { get; set; }
    }
}
