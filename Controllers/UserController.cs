using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using Newtonsoft.Json;

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

    [HttpGet("GetConcatenatedData")]
    public IActionResult GetConcatenatedData()
    {
        // Fetch data from the database
        var data = this._DBContext.Users.ToList();

        // Concatenate the data
        List<Dictionary<int, string>> concatenatedData = new List<Dictionary<int, string>>();
        foreach (var item in data)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, $"{item.Id} {item.Username} {item.FirstName} {item.LastName}");
            dict.Add(2, $"{item.Gender} {item.Email} {item.DateOfBirth} {item.Age}");
            dict.Add(3, $"{item.CompanyName} {item.Address} {item.City} {item.State}");
            dict.Add(4, $"{item.ZipCode} {item.Country} {item.PhoneNumber} {item.FaxNumber}");
            dict.Add(5, $"{item.Role} {item.Address2} {item.RegistrationDate} {item.AccountStatus}");

            concatenatedData.Add(dict);
        }

        if(data.Count == 0){
            return NotFound("Users not available");
        }
        return Ok(concatenatedData);
    }
}