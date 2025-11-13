using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly IStorage storage;

    public ContactManagementController(IStorage storage)
    {
        this.storage = storage;
    }
    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool result = storage.Add(contact);
        if (result) return Created();
        return Conflict("Пользователь с таким id уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContact());
    }
    // [HttpGet("contacts/{id}")]
    // public ActionResult<Contact> GetContactById(int id)
    // {
    //     if (id <= 0)
    //         return BadRequest("Не правильно введен id");
    //     var result = storage.GetContactById(id);
    //     if (result is null)
    //         return NotFound("id не найден");
    //     return Ok(result);

    // }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool result = storage.Remove(id);
        if (result) return NoContent();
        return BadRequest("Пользователя не удалось удалить\n Проверьте корректность id");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        bool result = storage.UpdateContact(contactDto, id);
        if (result) return Ok();
        return Conflict("Пользователь с таким id не нашелся");
    }

}