import React, { useEffect } from 'react'
import styles from "../../styles/cars/cars.module.css"
import { deleteCars, listCars } from '../../Redux/Actions/CarsAction';
import { useDispatch, useSelector } from "react-redux"
import Loading from '../../components/messages/Loading/Loading';
import Error from '../../components/messages/Error/Error';
import { useNavigate } from 'react-router-dom';

function Cars() {

    const navigate = useNavigate()
    const dispatch = useDispatch()

    const carsList = useSelector((state) => state.carsList);
    const { loading, error, cars } = carsList;

    const carsDelete = useSelector((state) => state.carsDelete)
    const { error: errorDelete, success: successDelete } = carsDelete;

    useEffect(() => {
        dispatch(listCars());
    }, [dispatch, successDelete])

    const addNew = () => {
        navigate("/create-cars")
    }

    const deleteCar = (id) => {
        if (window.confirm("Are you sure you want to delete this car?")) {
            dispatch(deleteCars(id))
        }
    }

    const updateCar = (id) => {
        navigate(`/update-car/${id}`)
    }

    return (
        <div className={styles.mainContainer}>
            <div className={styles.heading}>
                <h2 >CARS</h2>
                <button onClick={addNew}> Add new car</button>
            </div>
            {errorDelete && (<Error>{errorDelete}</Error>)}
            {
                loading ? (<Loading />) : error ? (<Error>{error}</Error>)
                    :
                    (
                        <div className={styles.tablePreview}>
                            <div className={styles.title}>
                                <h2>No</h2>
                                <h2>Brand</h2>
                                <h2>Registration</h2>
                            </div>

                            {cars.map((car, index) => {
                                return (
                                    <div className={styles.carPreview} key={car.id}>
                                        <div className={styles.tableContent}>
                                            <p>{index + 1}.</p>
                                            <p>{car.name}</p>
                                            <p>{car.registration}</p>
                                        </div>
                                        <div className={styles.buttons}>
                                            <button onClick={() => updateCar(car.id)}>Update</button>
                                            <button onClick={() => deleteCar(car.id)}>Delete</button>
                                        </div>
                                    </div>
                                )
                            })}
                        </div>
                    )
            }
        </div >
    )
}

export default Cars
