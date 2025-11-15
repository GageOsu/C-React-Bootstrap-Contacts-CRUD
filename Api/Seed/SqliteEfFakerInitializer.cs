using Bogus;
using Microsoft.EntityFrameworkCore;

class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext context;

    public SqliteEfFakerInitializer(SqliteDbContext context)
    {
        this.context = context;
    }

    public void Initialize()
    {
        context.Database.Migrate();
        if (!context.Contacts.Any())
        {
            var faker = new Faker<Contact>("ru")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email());

            var contacts = faker.Generate(20);

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}