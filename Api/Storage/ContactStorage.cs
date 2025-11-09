public class ContactStorage
{
    public ContactStorage()
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
    public List<Contact> Contacts { get; set; }
}