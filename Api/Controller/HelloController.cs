using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet("hello/{name}")]
    public string GetGreetingByName(string name)
    {
        return $"Привет, {name}!";
    }
}