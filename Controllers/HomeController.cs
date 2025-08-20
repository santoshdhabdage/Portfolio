using Microsoft.AspNetCore.Mvc;
using pr2.Models;
using System.Collections.Generic;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult About() => View();

    public IActionResult Skills()
    {
        var skills = new List<string>
        {
            "ASP.NET Core MVC",
            "C#",
            "Entity Framework Core",
            "SQL Server",
            "Bootstrap",
            "JavaScript",
            "HTML5 & CSS3"
        };

        return View(skills);
    }

    public IActionResult Projects()
    {
        var projects = new List<Project>
        {
            new Project
            {
                Title = "To-Do App",
                Description = "A task management system built using ASP.NET Core and EF Core with basic CRUD functionality.",
                ImageUrl = "/images/todo.png",
                ProjectLink = "https://github.com/yourusername/todo-app"
            },
            new Project
            {
                Title = "Support Ticket System",
                Description = "An enterprise-level ticketing system using ASP.NET Core MVC, Identity, and layered architecture.",
                ImageUrl = "/images/ticket.png",
                ProjectLink = "https://github.com/yourusername/support-ticket-system"
            }
        };

        return View(projects);
    }

    public IActionResult Resume()
    {
      

        return View();
    }
}
