using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly ContactStorage storage;

    public ContactManagementController(ContactStorage storage)
    {
        this.storage = storage;
    }
    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool result = storage.Add(contact);
        if (result) return Ok(contact);
        return Conflict("Пользователь с таким id уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContact());
    }

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