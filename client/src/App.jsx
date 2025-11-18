import axios from 'axios';
import { useState, useEffect } from 'react'
import TableContact from './layout/TableContact/TableContact'
import AppendContact from './layout/FormContact/AppendContact'
import { Route, Routes, useLocation } from 'react-router-dom';
import ContactDetails from './layout/ContactDetails/ContactDetails';
import Pagination from './layout/Pagination/Pagination';
import { Link } from 'react-router-dom';

const baseApiUrl = import.meta.env.VITE_API_URL;


const App = () => {

  const [contacts, setContacts] = useState([]);
  const location = useLocation();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [pageSize] = useState(10);
  const [updateTrigger, setUpdateTrigger] = useState(0);


  const handleUpdateTrigger = () => {
    setUpdateTrigger(updateTrigger + 1);
  }
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  }

  //page?pageNumber=1&pageSize=5
  useEffect(() => {
    const url = `${baseApiUrl}/contacts/page?pageNumber=${currentPage}&pageSize=${pageSize}`;
    axios.get(url).then(
      res => {
        setContacts(res.data.contacts);
        setTotalPages(Math.ceil(res.data.totalCount / pageSize))
      }
    );
  }, [currentPage, pageSize, location.pathname]);



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
              />
              <Pagination
                currentPage={currentPage}
                totalPages={totalPages}
                onPageChange={handlePageChange}
              />
              <Link to="/append"
                className="btn btn-success mt-3">
                Добавить контакт
              </Link>
            </div>
          </div>
        } />
        <Route path="contact/:id" element={<ContactDetails onUpdate={handleUpdateTrigger} />} />
        <Route path="append" element={<AppendContact />} />
      </Routes>
    </div>
  )
}

export default App
