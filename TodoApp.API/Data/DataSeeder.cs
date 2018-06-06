using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TodoApp.API.DataContext;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    /// <summary>
    /// This class is for seeding data
    /// </summary>
    public class DataSeeder
    {
        public readonly AppDataContext _context;
        public DataSeeder(AppDataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Executes Database Seeder
        /// NOTE: uncomment the codes after migration.
        /// </summary>
        public void SeedTodo(){
            //get fist data from database
            // var todo = _context.Todo.FirstOrDefault();

            // //if todo is null then populate the database
            // if(todo == null){
            //     //Read json file
            //     var todoData = File.ReadAllText("Data/TodoSeedData.json");
            //     //Deserialize object to list
            //     var todoList = JsonConvert.DeserializeObject<List<Todo>>(todoData);

            //     //Add todo list in one go
            //     _context.AddRange(todoList);

            //     //Save changes
            //     _context.SaveChanges();

            // }

        }
    }
}