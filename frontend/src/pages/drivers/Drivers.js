import React, { useEffect } from 'react'
import styles from "../../styles/drivers/drivers.module.css"
import { useDispatch, useSelector } from "react-redux"
import Loading from '../../components/messages/Loading/Loading';
import Error from '../../components/messages/Error/Error';
import { useNavigate } from 'react-router-dom';
import { deleteDrivers, listDrivers } from '../../Redux/Actions/DriversAction';

function Drivers() {

    const navigate = useNavigate()
    const dispatch = useDispatch()

    const driversList = useSelector((state) => state.driversList);
    const { loading, error, drivers } = driversList;

    const driversDelete = useSelector((state) => state.driversDelete)
    const { error: errorDelete, success: successDelete } = driversDelete;

    useEffect(() => {
        dispatch(listDrivers());
    }, [dispatch, successDelete])

    const addNew = () => {
        navigate("/create-drivers")
    }

    const deleteDriver = (id) => {
        if (window.confirm("Are you sure you want to delete this driver?")) {
            dispatch(deleteDrivers(id))
        }
    }

    const updateDriver = (id) => {
        navigate(`/update-driver/${id}`)
    }

    return (
        <div className={styles.mainContainer}>
            <div className={styles.heading}>
                <h2 >DRIVERS</h2>
                <button onClick={addNew}> Add new driver</button>
            </div>
            {errorDelete && (<Error>{errorDelete}</Error>)}
            {
                loading ? (<Loading />) : error ? (<Error>{error}</Error>)
                    :
                    (
                        <div className={styles.tablePreview}>
                            <div className={styles.title}>
                                <h2>No</h2>
                                <h2>Name</h2>
                                <h2>Last Name</h2>
                            </div>

                            {drivers.map((driver, index) => {
                                return (
                                    <div className={styles.carPreview} key={driver.id}>
                                        <div className={styles.tableContent}>
                                            <p>{index + 1}.</p>
                                            <p>{driver.name}</p>
                                            <p>{driver.lastName}</p>
                                        </div>
                                        <div className={styles.buttons}>
                                            <button onClick={() => updateDriver(driver.id)}>Update</button>
                                            <button onClick={() => deleteDriver(driver.id)}>Delete</button>
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

export default Drivers
