import { useState } from 'react'

function App() {
  return (
    <div>
      <div>
        <div>
          <h1>Список контактов</h1>
        </div>
        <div>
          <table>
            <thead>
              <tr>
                <th>#</th>
                <th>Имя контакта</th>
                <th>E-mail</th>
              </tr>
            </thead>
            <tbody>

              <tr>
                <th>1</th>
                <th>Имя Фамилия</th>
                <th>example@gma.com</th>
              </tr>

              <tr>
                <th>2</th>
                <th>Имя Фамилия 22</th>
                <th>example22@gma.com</th>
              </tr>

              <tr>
                <th>3</th>
                <th>Имя Фамилия 33</th>
                <th>example33@gma.com</th>
              </tr>

            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

export default App
