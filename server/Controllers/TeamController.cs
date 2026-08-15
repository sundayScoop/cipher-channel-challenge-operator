using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers;

[Authorize(Roles = "Administrator")]
public class TeamController(ITeamService teamService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Attack()
    {
        return View();
    }

    public IActionResult Register(Team newTeam)
    {
        teamService.RegisterTeam(newTeam);
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
