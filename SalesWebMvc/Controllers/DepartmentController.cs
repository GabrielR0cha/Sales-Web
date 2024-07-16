using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers;

public class DepartmentController : Controller
{
    public IActionResult Index()
    {
        List<Department> list = new List<Department>();

        list.Add(new Department { Id = 1, Name = "Gabriel"} );
        list.Add(new Department { Id = 2, Name = "Luis" });


        return View(list);
    }
}
