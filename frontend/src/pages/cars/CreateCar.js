import React, { useState, useEffect } from 'react'
import styles from '../../styles/cars/createCars.module.css'
import { BrandsEnum } from './Brands'
import { toast } from 'react-toastify'
import { CARS_CREATE_RESET } from '../../Redux/Constants/CarsConstants'
import Toast from '../../components/messages/Toast/Toast'
import Loading from '../../components/messages/Loading/Loading'
import Error from '../../components/messages/Error/Error'
import { createCars } from '../../Redux/Actions/CarsAction'
import { useDispatch, useSelector } from 'react-redux'

function CreateCar() {

    const [name, setName] = useState("")
    const [registration, setRegistration] = useState("")

    const dispatch = useDispatch();

    const carsCreate = useSelector((state) => (state.carsCreate));
    const { error, loading, success } = carsCreate;

    useEffect(() => {
        if (success) {
            toast.success("Car Added!")
            dispatch({ type: CARS_CREATE_RESET });
            setName("");
            setRegistration("");
        }
    }, [success, dispatch])

    const handleSubmit = (e) => {
        e.preventDefault()
        dispatch(createCars(name, registration))
    }

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Add new car</h2>
            <form onSubmit={handleSubmit}>
                {error && <Error>{error}</Error>}
                {loading && <Loading />}
                <label>
                    Car Brand:
                </label>
                <select
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                >
                    {Object.values(BrandsEnum).map((brand) => (
                        <option key={brand} value={brand}>
                            {brand}
                        </option>
                    ))}
                </select>
                <label>
                    Car Registration: (example: ZG-1523-DL)
                </label>
                <input type='text' value={registration} onChange={(e) => setRegistration(e.target.value)} />

                <button>Add Car</button>
            </form>
        </div>
    )
}

export default CreateCar
