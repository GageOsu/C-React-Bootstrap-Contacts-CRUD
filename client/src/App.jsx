import { useState } from 'react'
import TableContact from './layout/TableContact/TableContact'
import FormContact from './layout/FormContact/FormContact'

const App = () => {

  const [contacts, setContacts] = useState(
    [
      { id: 1, name: "Popa Pipa", email: "example@zxc.com", },
      { id: 2, name: "Pipa Popa", email: "example@zxc.com", },
      { id: 3, name: "Алексей Шевцовzxc", email: "карлик@10см.com", },
    ]
  );
  const addContact = (contactName, contactEmail) => {
    const newId = contacts
      .sort((x, y) => x.Id - y.id)[contacts.length - 1]
      .id + 1
      ;
    const item = {
      id: newId,
      name: contactName,
      email: contactEmail,
    };
    setContacts([...contacts, item]);
  }

  const deleteContact = (id) => {
    setContacts(contacts.filter(item => item.id !== id));
  }

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact
            contacts={contacts}
            deleteContact={deleteContact}
          />
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  )
}

export default App
