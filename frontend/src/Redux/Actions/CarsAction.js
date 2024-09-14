
import {
    CARS_CREATE_FAIL,
    CARS_CREATE_REQUEST,
    CARS_CREATE_SUCCESS,
    CARS_DELETE_FAIL,
    CARS_DELETE_REQUEST,
    CARS_DELETE_SUCCESS,
    CARS_LIST_FAIL,
    CARS_LIST_REQUEST,
    CARS_LIST_SUCCESS,
} from "../Constants/CarsConstants"
import axios from "../../api/axios";

// CARS LIST
export const listCars = () => async (dispatch) => {
    try {
        dispatch({ type: CARS_LIST_REQUEST })
        const { data } = await axios.get("/api/Cars");
        dispatch({ type: CARS_LIST_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: CARS_LIST_FAIL,
            payload: message
        });
    }
}

// DELETE CARS
export const deleteCars = (id) => async (dispatch) => {
    try {
        dispatch({ type: CARS_DELETE_REQUEST })
        await axios.delete(`/api/Cars/${id}`);
        dispatch({ type: CARS_DELETE_SUCCESS })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: CARS_DELETE_FAIL,
            payload: message
        });
    }
}

// CREATE CARS
export const createCars = (name, registration) => async (dispatch) => {
    try {
        dispatch({ type: CARS_CREATE_REQUEST })

        const { data } = await axios.post(
            `/api/Cars`,
            { name, registration }
        );
        dispatch({ type: CARS_CREATE_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: CARS_CREATE_FAIL,
            payload: message
        });
    }
}