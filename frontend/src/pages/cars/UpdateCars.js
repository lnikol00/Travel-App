import React, { useState, useEffect } from 'react'
import { useParams } from "react-router-dom"
import styles from "../../styles/cars/createCars.module.css"
import { BrandsEnum } from './Brands'
import { toast } from 'react-toastify'
import Toast from '../../components/messages/Toast/Toast'
import Loading from '../../components/messages/Loading/Loading'
import Error from '../../components/messages/Error/Error'
import { createCars, editCars } from '../../Redux/Actions/CarsAction'
import { useDispatch, useSelector } from 'react-redux'


function UpdateCars() {

    const [name, setName] = useState("");
    const [registration, setRegistration] = useState("");

    const params = useParams();
    const carId = params.id;

    const dispatch = useDispatch();

    const carsEdit = useSelector((state) => (state.carsEdit));
    const { error, loading, car } = carsEdit;

    useEffect(() => {
        if (car !== null && (car?.id !== carId)) {
            dispatch(editCars(carId))
        }
        else {
            setName(`${car.name}`);
            setRegistration(`${car.registration}`);
        }

    }, [car, dispatch, carId])


    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Add new car</h2>
            {error && <Error>{error}</Error>}
            {loading && <Loading />}
            <form>
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

                <button>Update Car</button>
            </form>
        </div>
    )
}

export default UpdateCars
