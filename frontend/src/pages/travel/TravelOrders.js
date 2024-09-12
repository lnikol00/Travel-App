import React, { useEffect } from 'react'
import styles from "../../styles/travel/travel.module.css"
import { useDispatch, useSelector } from "react-redux"
import { deleteTravel, listTravel } from '../../Redux/Actions/TravelOrdersAction';
import Loading from '../../components/messages/Loading/Loading';
import Error from '../../components/messages/Error/Error';
import { useNavigate } from 'react-router-dom';

function TravelOrders() {

    const navigate = useNavigate()
    const dispatch = useDispatch()

    const travelList = useSelector((state) => state.travelList);
    const { loading, error, travelOrders } = travelList;

    const travelDelete = useSelector((state) => state.travelDelete)
    const { error: errorDelete, success: successDelete } = travelDelete;

    useEffect(() => {
        dispatch(listTravel());
    }, [dispatch, successDelete])

    const addNew = () => {
        navigate("/create-travel-orders")
    }

    const deleteTravelOrder = (id) => {
        if (window.confirm("Are you sure you want to delete this travel order?")) {
            dispatch(deleteTravel(id))
        }
    }

    const updateTravelOrder = (id) => {
        navigate(`/update-travel-order/${id}`)
    }

    return (
        <div className={styles.mainContainer}>
            <div className={styles.heading}>
                <h2 >TRAVEL ORDERS</h2>
                <button onClick={addNew}> Add new travel order</button>
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
                                <h2>Brand</h2>
                                <h2>Registration</h2>
                                <h2>Date</h2>
                                <h2>Mileage</h2>
                                <h2>Route</h2>
                            </div>

                            {travelOrders.map((travelOrder, index) => {
                                return (
                                    <div className={styles.carPreview} key={travelOrder.id}>
                                        <div className={styles.tableContent}>
                                            <p>{index + 1}.</p>
                                            <p>{travelOrder.name}</p>
                                            <p>{travelOrder.lastName}</p>
                                            <p>{travelOrder.brand}</p>
                                            <p>{travelOrder.registration}</p>
                                            <p>{new Date(travelOrder.date).toISOString().split('T')[0]}</p>
                                            <p>{travelOrder.mileage} km</p>
                                            <p>{travelOrder.route}</p>
                                        </div>
                                        <div className={styles.buttons}>
                                            <button onClick={() => updateTravelOrder(travelOrder.id)}>Update</button>
                                            <button onClick={() => deleteTravelOrder(travelOrder.id)}>Delete</button>
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

export default TravelOrders
