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
    public void Create([FromBody] Contact contact)
    {
        storage.Add(contact);
    }

    [HttpGet("contacts")]
    public List<Contact> GetContacts()
    {
        return storage.GetContact();
    }

    [HttpDelete("contacts/{id}")]
    public void DeleteContact(int id)
    {
        storage.Remove(id);
    }

    [HttpPut("contacts/{id}")]
    public void UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        storage.UpdateContact(contactDto, id);
    }

}