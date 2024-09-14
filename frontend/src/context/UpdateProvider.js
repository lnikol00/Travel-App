import React, { createContext, useState, useRef } from 'react';
import axios from '../api/axios';
import { toast } from 'react-toastify';

const UpdateContext = createContext(null);

export const UpdateProvider = ({ children }) => {
    const [car, setCar] = useState(null);
    const [driver, setDriver] = useState(null);
    const [travelOrder, setTravelOrder] = useState(null)
    const [errMsg, setErrMsg] = useState('');
    const errRef = useRef(null);


    // GET CAR BY ID
    const fetchCar = async (id) => {
        try {
            const { data } = await axios.get(`/api/Cars/${id}`);
            setCar(data);
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("No server response");
            } else if (err.response?.status === 404) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    // UPDATE CAR
    const handleEditCar = async (id, name, registration) => {
        try {
            const updateCar = {
                name,
                registration,
            };

            const editCar = await axios.put(`/api/Cars/${id}`, updateCar, {
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                },
            });
            console.log("Car Edited!");
            toast.success("Car Edited!");
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("Server not responding");
            } else if (err.response?.status === 400) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    // GET DRIVER BY ID
    const fetchDriver = async (id) => {
        try {
            const { data } = await axios.get(`/api/Employee/${id}`);
            setDriver(data);
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("No server response");
            } else if (err.response?.status === 404) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    // UPDATE DRIVER
    const handleEditDriver = async (id, name, lastName) => {
        try {
            const updateDriver = {
                name,
                lastName,
            };

            const editDriver = await axios.put(`/api/Employee/${id}`, updateDriver, {
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                },
            });
            console.log("Driver Edited!");
            toast.success("Driver Edited!")
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("Server not responding");
            } else if (err.response?.status === 400) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    // GET CAR BY ID
    const fetchTravelOrder = async (id) => {
        try {
            const { data } = await axios.get(`/api/TravelOrders/${id}`);
            setTravelOrder(data);
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("No server response");
            } else if (err.response?.status === 404) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };

    // UPDATE DRIVER
    const handleEditTravelOrder = async (id, employeeId, carsId, date, mileage, route) => {
        try {
            const updateTravelOrder = {
                employeeId,
                carsId,
                date,
                mileage,
                route
            };

            const editTravelOrder = await axios.put(`/api/TravelOrders/${id}`, updateTravelOrder, {
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                },
            });
            console.log("Travel Order Edited!");
            toast.success("Travel Order Edited!")
        } catch (error) {
            const err = error;
            if (!err.response) {
                setErrMsg("Server not responding");
            } else if (err.response?.status === 400) {
                setErrMsg(`${err.response.data}`);
            }
            if (errRef.current) errRef.current.focus();
        }
    };


    return (
        <UpdateContext.Provider value={{ car, fetchCar, handleEditCar, driver, fetchDriver, handleEditDriver, travelOrder, fetchTravelOrder, handleEditTravelOrder, errMsg, setErrMsg }}>
            {children}
        </UpdateContext.Provider>
    );
};

export default UpdateContext;