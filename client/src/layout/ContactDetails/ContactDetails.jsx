import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
const baseApiUrl = import.meta.env.VITE_API_URL;

const ContactDetails = () => {
    const [contact, setContacts] = useState({ name: "", email: "" });
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.get(url).then(
            response => setContacts(response.data)
        ).catch(
            err => {
                navigate("/");
            }
        )
    }, [id, navigate]);

    const handleRemove = () => {
        const url = `${baseApiUrl}/contacts/${id}`;
        if (window.confirm("Вы уверены что хотите удалить контакт?")) {
            axios.delete(url).then(
                navigate("/")
            ).catch(
                console.log("Ошибка удаления")
            );
        }
    }

    const handleUpdate = () => {
        const url = `${baseApiUrl}/contacts/${id}`;
        if (window.confirm("Вы уверены что хотите обновить контакт?")) {
            axios.put(url, contact).then(
                navigate("/")
            ).catch(
                console.log("Ошибка обновления")
            );
        }
    }



    return (
        <div className="container">
            <h2>Детали контакта</h2>
            <div className="mb-3">
                <label className="form-label">Имя: </label>
                <input
                    className="form-control"
                    type="text"
                    value={contact.name}
                    onChange={(e) => { setContacts({ ...contact, name: e.target.value }); }}
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Email: </label>
                <input
                    className="form-control"
                    type="email"
                    value={contact.email}
                    onChange={(e) => { setContacts({ ...contact, email: e.target.value }); }}
                />
            </div>
            <button className="btn btn-primary me-2" onClick={(e) => { handleUpdate(); }}>
                Обновит
            </button>


            <button className="btn btn-danger me-2" onClick={(e) => { handleRemove(); }}>
                Удалить
            </button>
            <button className="btn btn-secondary ms-2" onClick={(e) => { navigate("/"); }}>
                Назад
            </button>
        </div>);
}

export default ContactDetails;