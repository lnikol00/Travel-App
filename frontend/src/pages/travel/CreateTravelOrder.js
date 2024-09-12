import React, { useState, useEffect } from 'react'
import styles from '../../styles/cars/createCars.module.css'
import { toast } from 'react-toastify'
import { TRAVEL_CREATE_RESET } from '../../Redux/Constants/TravelOrdersConstants'
import Toast from '../../components/messages/Toast/Toast'
import Loading from '../../components/messages/Loading/Loading'
import Error from '../../components/messages/Error/Error'
import { createTravel } from '../../Redux/Actions/TravelOrdersAction'
import { useDispatch, useSelector } from 'react-redux'

function CreateTravelOrder() {

    const [employeeId, setEmployeeId] = useState(1)
    const [carsId, setCarsId] = useState(1)
    const [date, setDate] = useState("")
    const [mileage, setMileage] = useState(0)
    const [route, setRoute] = useState("");

    const dispatch = useDispatch();

    const travelCreate = useSelector((state) => (state.travelCreate));
    const { error, loading, success } = travelCreate;

    const carsList = useSelector((state) => state.carsList);
    const { cars } = carsList;

    const driversList = useSelector((state) => state.driversList);
    const { drivers } = driversList;

    useEffect(() => {
        if (success) {
            toast.success("Travel Order Added!")
            dispatch({ type: TRAVEL_CREATE_RESET });
            setEmployeeId(1);
            setCarsId(1);
            setDate("");
            setMileage(0);
            setRoute("");
        }
    }, [success, dispatch])

    const handleSubmit = (e) => {
        e.preventDefault()
        dispatch(createTravel(employeeId, carsId, date, mileage, route))
    }

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Add new car</h2>
            <form onSubmit={handleSubmit}>
                {error && <Error>{error}</Error>}
                {loading && <Loading />}
                <label>
                    Driver
                </label>
                <select
                    value={employeeId}
                    onChange={(e) => setEmployeeId(e.target.value)}
                >
                    {drivers.map((driver) => (
                        <option key={driver.id} value={driver.id}>
                            {driver.name} {driver.lastName}
                        </option>
                    ))}
                </select>
                <label>
                    Car Brand:
                </label>
                <select
                    value={carsId}
                    onChange={(e) => setCarsId(e.target.value)}
                >
                    {cars.map((car) => (
                        <option key={car.id} value={car.id}>
                            {car.name}
                        </option>
                    ))}
                </select>
                <label>
                    Date
                </label>
                <input required type='date' value={date} onChange={(e) => setDate(e.target.value)} />

                <label>
                    Mileage
                </label>
                <input required type='number' value={mileage} onChange={(e) => setMileage(e.target.value)} />
                <label>
                    Route: (example: Zagreb-Split)
                </label>
                <input required type='text' value={route} onChange={(e) => setRoute(e.target.value)} />

                <button>Add Travel Order</button>
            </form>
        </div>
    )
}

export default CreateTravelOrder
