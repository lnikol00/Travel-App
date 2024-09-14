import React, { useState, useEffect, useRef } from 'react'
import styles from '../../styles/cars/createCars.module.css'
import Toast from '../../components/messages/Toast/Toast'
import { useDispatch, useSelector } from 'react-redux'
import { useParams } from "react-router-dom"
import useUpdate from '../../hooks/useUpdate'
import { listDrivers } from '../../Redux/Actions/DriversAction'
import { listCars } from '../../Redux/Actions/CarsAction'
import moment from 'moment'

function UpdateTravelOrder() {

    const [employeeId, setEmployeeId] = useState(1)
    const [carsId, setCarsId] = useState(1)
    const [date, setDate] = useState("")
    const [mileage, setMileage] = useState(0)
    const [route, setRoute] = useState("");

    const { travelOrder, fetchTravelOrder, handleEditTravelOrder, errMsg, setErrMsg } = useUpdate();

    const params = useParams();

    useEffect(() => {
        setErrMsg('');
    }, [employeeId, carsId, date, mileage, route])

    const formatDate = (dateString) => {
        return moment(dateString).format('YYYY-MM-DD');
    };

    useEffect(() => {
        setEmployeeId(`${travelOrder?.employeeId}`)
        setCarsId(`${travelOrder?.carsId}`)

        const formattedDate = formatDate(`${travelOrder?.date}`);
        setDate(formattedDate);

        setMileage(`${travelOrder?.mileage}`)
        setRoute(`${travelOrder?.route}`)

    }, [travelOrder?.employeeId, travelOrder?.carsId, travelOrder?.date, travelOrder?.mileage, travelOrder?.route])


    useEffect(() => {
        if (params.id) {
            fetchTravelOrder(params.id);
        }
    }, [params.id]);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(listDrivers());
        dispatch(listCars());
    }, [dispatch])


    const carsList = useSelector((state) => state.carsList);
    const { cars } = carsList;

    const driversList = useSelector((state) => state.driversList);
    const { drivers } = driversList;

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (params.id) {
            await handleEditTravelOrder(params.id, employeeId, carsId, date, mileage, route);
        }
    };

    return (
        <div className={styles.mainContainer}>
            <Toast />
            <h2>Update Travel Order</h2>
            <form onSubmit={handleSubmit}>
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
                <input type='date' required value={date} onChange={(e) => setDate(e.target.value)} />

                <label>
                    Mileage
                </label>
                <input type='number' required value={mileage} onChange={(e) => setMileage(e.target.value)} />
                <label>
                    Route:
                </label>
                <input type='text' required value={route} onChange={(e) => setRoute(e.target.value)} />

                <button>Update Travel Order</button>
            </form>
        </div>
    )
}

export default UpdateTravelOrder
