using System.Text;
using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage
{

    string connectionString = "Data Source=contacts.db";
    public bool Add(Contact contact)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();

        string sql = "INSERT INTO contacts(name, email) VALUES (@name, @email);";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);

        Console.WriteLine("sql >> " + sql);
        return command.ExecuteNonQuery() > 0;

    }

    public List<Contact> GetContact()
    {
        var contact = new List<Contact>();

        string connectionString = "Data Source=contacts.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            contact.Add(new Contact()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
            });
        }

        return contact;
    }

    public bool Remove(int id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateContact(ContactDto contactDto, int id)
    {
        throw new NotImplementedException();
    }
}