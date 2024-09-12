import React, { useState, useEffect } from 'react'
import styles from '../../styles/drivers/createDrivers.module.css'
import { toast } from 'react-toastify'
import Toast from '../../components/messages/Toast/Toast'
import Loading from '../../components/messages/Loading/Loading'
import Error from '../../components/messages/Error/Error'
import { useDispatch, useSelector } from 'react-redux'
import { DRIVERS_CREATE_RESET } from '../../Redux/Constants/DriverConstants'
import { createDrivers } from '../../Redux/Actions/DriversAction'

function CreateDriver() {

    const [name, setName] = useState("")
    const [lastName, setLastName] = useState("")

    const dispatch = useDispatch();

    const driversCreate = useSelector((state) => (state.driversCreate));
    const { error, loading, success } = driversCreate;

    useEffect(() => {
        if (success) {
            toast.success("Driver Added!")
            dispatch({ type: DRIVERS_CREATE_RESET });
            setName("");
            setLastName("");
        }
    }, [success, dispatch])

    const handleSubmit = (e) => {
        e.preventDefault()
        dispatch(createDrivers(name, lastName));
    }

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Add new driver</h2>
            <form onSubmit={handleSubmit}>
                {error && <Error>{error}</Error>}
                {loading && <Loading />}
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

export default CreateDriver
