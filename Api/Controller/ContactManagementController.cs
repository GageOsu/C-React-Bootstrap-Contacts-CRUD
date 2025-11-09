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
        storage.Contacts.Add(contact);
    }
}