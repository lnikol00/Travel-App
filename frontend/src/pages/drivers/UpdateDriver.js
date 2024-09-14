import React, { useState, useEffect, useRef } from 'react'
import styles from '../../styles/drivers/createDrivers.module.css'
import { useParams } from "react-router-dom"
import Toast from '../../components/messages/Toast/Toast'
import useUpdate from '../../hooks/useUpdate'


function UpdateDriver() {

    const [name, setName] = useState("");
    const [lastName, setLastName] = useState("");

    const errRef = useRef(null)
    const { driver, fetchDriver, handleEditDriver, errMsg, setErrMsg } = useUpdate();

    const params = useParams();

    useEffect(() => {
        setErrMsg('');
    }, [name, lastName])

    useEffect(() => {
        setName(`${driver?.name}`)
        setLastName(`${driver?.lastName}`)

        console.log(`${name} ${lastName}`)
    }, [driver?.name, driver?.lastName])


    useEffect(() => {
        if (params.id) {
            fetchDriver(params.id);
        }
    }, [params.id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (params.id) {
            await handleEditDriver(params.id, name, lastName);
        }
    };

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Add new driver</h2>
            <p ref={errRef} className={errMsg ? `${styles.errmsg}` : `${styles.offscreen}`} aria-live="assertive">
                {errMsg}
            </p>
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                </label>
                <input type='text' required value={name} onChange={(e) => setName(e.target.value)} />
                <label>
                    Last Name
                </label>
                <input type='text' required value={lastName} onChange={(e) => setLastName(e.target.value)} />

                <button>Add Driver</button>
            </form>
        </div>
    )
}

export default UpdateDriver
