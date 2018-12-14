using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoServer.Models;

namespace TodoServer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(LoadHTMLPage("Views/TodoApp/index"), "text/html");
        }


        #region helpers

        private string LoadHTMLPage(string path)
        {
            return System.IO.File.ReadAllText($"{ path }.html");
        }


        #endregion
    }
}
