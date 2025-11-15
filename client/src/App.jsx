import axios from 'axios';
import { useState, useEffect } from 'react'
import TableContact from './layout/TableContact/TableContact'
import FormContact from './layout/FormContact/FormContact'
import { Route, Routes } from 'react-router-dom';

const baseApiUrl = import.meta.env.VITE_API_URL;
console.log(baseApiUrl);


const App = () => {

  const [contacts, setContacts] = useState([]);

  const url = `${baseApiUrl}/contacts`;
  useEffect(() => {
    axios.get(url).then(
      res => setContacts(res.data)
    );
  }, []);

  const addContact = (contactName, contactEmail) => {
    const item = {
      name: contactName,
      email: contactEmail,
    };
    const url = `${baseApiUrl}/contacts`;
    axios.post(url, item).then(
      response => setContacts([...contacts, response.data]))
  };
  const deleteContact = (id) => {
    setContacts(contacts.filter(item => item.id !== id))
    const urldelete = `${baseApiUrl}/contacts/${id}`;
    axios.delete(urldelete);
  }

  return (
    <div className="container mt-5">
      <Routes>
        <Route path="/" element={
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
        } />
        <Route path="contact/:id" element={<>Hello</>} />
      </Routes>
    </div>
  )
}

export default App
