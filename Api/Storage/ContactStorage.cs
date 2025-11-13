using Microsoft.AspNetCore.Routing.Tree;

public class InMemoryStorage : IStorage
{
    private List<Contact> Contacts { get; set; }
    public InMemoryStorage()
    {
        this.Contacts = new List<Contact>();

        for (int i = 0; i < 5; i++)
        {
            this.Contacts.Add(new Contact()
            {
                Id = i + 1,
                Name = $"Полное имя {i + 1}",
                Email = $"example{i + 1}@testmail.com",
            });
        }
    }


    public List<Contact> GetContact()
    {
        return Contacts;
    }

    public Contact GetContactById(int id)
    {
        return Contacts.FirstOrDefault(e => e.Id == id);
    }

    public bool Add(Contact contact)
    {
        foreach (var item in Contacts)
        {
            if (contact.Id == item.Id)
            {
                return false;
            }
        }
        Contacts.Add(contact);
        return true;
    }

    public bool Remove(int id)
    {
        Contact contact;
        for (int i = 0; i < Contacts.Count; i++)
        {
            if (this.Contacts[i].Id == id)
            {
                contact = Contacts[i];
                Contacts.Remove(contact);
                return true;
            }
        }
        return false;
    }

    public bool UpdateContact(ContactDto contactDto, int id)
    {
        Contact contact;
        for (int i = 0; i < Contacts.Count; i++)
        {
            if (Contacts[i].Id == id)
            {
                contact = Contacts[i];
                if (!String.IsNullOrEmpty(contactDto.Email))
                {
                    contact.Email = contactDto.Email;
                }
                if (!String.IsNullOrEmpty(contactDto.Name))
                {
                    contact.Name = contactDto.Name;
                }
                return true;
            }
        }
        return false;
    }
}