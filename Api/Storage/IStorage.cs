public interface IStorage
{
    List<Contact> GetContact();
    bool Add(Contact contact);
    bool Remove(int id);
    bool UpdateContact(ContactDto contactDto, int id);
}
