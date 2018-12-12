﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoServer.Data;
using TodoServer.Data.Models;
using TodoServer.Models.ApiModels;
using TodoServer.services;

namespace TodoServer.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    public class TodosApiController : Controller
    {
        private TodosService _todosService;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        // for testing
        private string UserId = "99424be2-88ed-4bc8-9c8e-99901001edc8";

        public TodosApiController(
            TodosService todosService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _todosService = todosService;
            _userManager = userManager;
            _context = context;
        }

        [Route("api/todos/get-all")]
        public IActionResult GetAll()
        {
            var todos = _todosService.GetAll(UserId);
            var response = todos.Select(x => new
            {
                id = x.Id,
                text = x.Text,
                completed = x.Completed
            });
            return Ok(response);
        }

        [Route("api/todos/create")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateTodoModel model)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo
                {
                    Completed = false,
                    Text = model.Text,
                    User = (ApplicationUser)_context.Users.FirstOrDefault(x => x.Id == UserId)
                };

                var result = _todosService.Create(todo);

                var response = new
                {
                    id = result.Id,
                    text = result.Text,
                    completed = result.Completed
                };
                
                return Ok(response);
            }

            return BadRequest(ModelState);

        }

        [Route("api/todos/edit")]
        [HttpPost]
        public IActionResult Edit([FromBody] EditTodoModel model)
        {

            if(ModelState.IsValid)
            {
                _todosService.Edit(model.TodoId, model.NewTodoText);
                return Ok();
            }


            return BadRequest(ModelState);
        }

        [Route("api/todos/delete/{todoId}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int todoId)
        {
            var result = _todosService.Delete(todoId);

            if(result == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("api/todos/toggle-completed/{todoId}")]
        [HttpGet]
        public IActionResult ToggleCompleted([FromRoute] int todoId)
        {
            _todosService.ToggleCompleted(todoId);
            return Ok();
        }


        #region helpers

        private string CurrentUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }


        #endregion
    }
}