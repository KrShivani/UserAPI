using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DemoAPIContext _DBContext;

    public UserController(DemoAPIContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var product = this._DBContext.Users.ToList();
        if(product.Count == 0){
            return NotFound("Users not available");
        }
        return Ok(product);
    }
}