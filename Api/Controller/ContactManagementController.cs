using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly IPaginationStorage storage;

    public ContactManagementController(IPaginationStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        Contact result = storage.Add(contact);
        if (result != null) return Ok(contact);
        return Conflict("Пользователь с таким id уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContacts());
    }


    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> GetContacts(int id)
    {
        var contact = storage.GetContactById(id);
        if (contact != null) return Ok(contact);

        return NotFound();
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
    [HttpGet("contacts/page")]
    public IActionResult GetContacts(int pageNumber = 1, int pageSize = 5)
    {
        var (contacts, total) = storage.GetContacts(pageNumber, pageSize);

        var response = new
        {
            Contacts = contacts,
            TotalCount = total,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };

        return Ok(response);
    }

}