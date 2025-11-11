import { useState } from 'react'
import TableContact from './layout/TableContact/TableContact'

const contacts = [
  { id: 1, name: "Popa Pipa", email: "example@zxc.com", },
  { id: 2, name: "Pipa Popa", email: "example@zxc.com", },
  { id: 3, name: "Алексей Шевцовzxc", email: "карлик@10см.com", },
]

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts} />
        </div>
      </div>
    </div>
  )
}

export default App
