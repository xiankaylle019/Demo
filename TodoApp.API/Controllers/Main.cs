using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.API.Controllers
{
    public class Main: Controller
    {
        public IActionResult Index(){
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","index.html"),"text/HTML");
        }
    }
}