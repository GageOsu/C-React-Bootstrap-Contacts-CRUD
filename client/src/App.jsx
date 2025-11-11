import { useState } from 'react'
import TableContact from './layout/TableContact/TableContact'

const contacts = [
  { id: 1, name: "Popa Pipa", email: "example@zxc.com", },
  { id: 2, name: "Pipa Popa", email: "example@zxc.com", },
  { id: 3, name: "Алексей Шевцовzxc", email: "карлик@10см.com", },
]
const addContact = () => {
  const item = {
    id: Math.floor(Math.random() * 10),
    name: "Алексей Шевцовzxc",
    email: "карлик@10см.com",
  };
  contacts.push(item);
  console.log(contacts);
}

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts} />
          <div>
            <button
              className="btn btn-primary"
              onClick={() => { addContact() }}
            >
              Добавить контакт
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

export default App
