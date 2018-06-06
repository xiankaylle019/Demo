using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.DataContext;
using TodoApp.API.Models;

namespace TodoApp.API.Controllers
{
    
    public class TodoApiController : Controller
    {
        //read only variable AppDataContext
        private readonly AppDataContext _context;
        //Todo Api Controller constructor
        public TodoApiController(AppDataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get todo list
        /// </summary>
        /// <returns></returns>
         // GET api/todoapi
        [Route("api/get")]
        [HttpGet]
        public async Task<IEnumerable<Todo>> Get()
        {
            var todoList =  await _context.Todo
            .OrderByDescending(o => o.CreatedOn)
            .ToListAsync();

            return todoList;
        }
        /// <summary>
        /// Get todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // Get api/todoapi/1
        [Route("api/getbyid/{id}")]
        [HttpGet]
     
        public async Task<Todo> GetById(int id){

            var todo =  await _context.Todo.SingleOrDefaultAsync(e=>e.Id == id);

            return todo;
        }
        /// <summary>
        /// Add new todo
        /// </summary>
        /// <param name="todo"></param>
        // POST api/todoapi/addtodo
        [Route("api/addtodo")]
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody]Todo todo)
        {   
            todo.CreatedOn = DateTime.Now;
            _context.Add(todo);

            if(await _context.SaveChangesAsync() > 0) 
                return CreatedAtRoute(new { isSaved = true }, "Your todo is Successfully added");
           
            throw new Exception("Creating todo failed on save");

        }
        /// <summary>
        /// Update Todo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        // PUT api/values/5
        [Route("api/updatedtodo/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatedTodo(int id, [FromBody]Todo todo)
        {   
            var todoData = await _context.Todo.SingleOrDefaultAsync(d => d.Id == id);

            if(todoData != null) {

                todoData.IsAccomplished = todo.IsAccomplished;
                todoData.Description = todo.Description;
                todoData.LastUpdatedOn = DateTime.Now;

                if(await _context.SaveChangesAsync() > 0) 
                    return CreatedAtRoute(new { TodoData = todoData }, "Successfully Updated");
            }

            throw new Exception($"Failed updating todo id:  {id}");
        
        }
        /// <summary>
        /// Delete Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/deletetodo/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(int id)
        {   
            var todoData = await _context.Todo.SingleOrDefaultAsync(d => d.Id == id);

            if(todoData != null) {

                todoData.IsDeleted = true;
                todoData.LastUpdatedOn = DateTime.Now;

                if(await _context.SaveChangesAsync() > 0) 
                    return CreatedAtRoute(new { TodoData = todoData }, "Successfully Deleted");
            }

            throw new Exception($"Failed deleting todo id:  {id}");
        
        }
    }
}