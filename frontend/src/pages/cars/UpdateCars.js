import React, { useState, useEffect, useRef } from 'react'
import { useParams } from "react-router-dom"
import Toast from '../../components/messages/Toast/Toast'
import styles from "../../styles/cars/createCars.module.css"
import { BrandsEnum } from './Brands'
import useUpdate from '../../hooks/useUpdate'


function UpdateCars() {

    const [name, setName] = useState("");
    const [registration, setRegistration] = useState("");
    const errRef = useRef(null)
    const { car, fetchCar, handleEditCar, errMsg, setErrMsg } = useUpdate();

    const params = useParams();

    useEffect(() => {
        setErrMsg('');
    }, [name, registration])

    useEffect(() => {
        setName(`${car?.name}`)
        setRegistration(`${car?.registration}`)

        console.log(`${name} ${registration}`)
    }, [car?.name, car?.registration])


    useEffect(() => {
        if (params.id) {
            fetchCar(params.id);
        }
    }, [params.id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (params.id) {
            await handleEditCar(params.id, name, registration);
        }
    };

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Update car</h2>
            <p ref={errRef} className={errMsg ? `${styles.errmsg}` : `${styles.offscreen}`} aria-live="assertive">
                {errMsg}
            </p>
            <form onSubmit={handleSubmit}>
                <label>
                    Car Brand:
                </label>
                <select

                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                >
                    {Object.values(BrandsEnum).map((brand) => (
                        <option key={brand} value={brand}>
                            {brand}
                        </option>
                    ))}
                </select>
                <label>
                    Car Registration:
                </label>
                <input type='text'
                    required
                    value={registration}
                    onChange={(e) => setRegistration(e.target.value)} />

                <button>Update Car</button>
            </form>
        </div>
    )
}

export default UpdateCars
