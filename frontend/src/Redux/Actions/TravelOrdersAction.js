
import {
    TRAVEL_CREATE_FAIL,
    TRAVEL_CREATE_REQUEST,
    TRAVEL_CREATE_SUCCESS,
    TRAVEL_DELETE_FAIL,
    TRAVEL_DELETE_REQUEST,
    TRAVEL_DELETE_SUCCESS,
    TRAVEL_EDIT_FAIL,
    TRAVEL_EDIT_REQUEST,
    TRAVEL_EDIT_SUCCESS,
    TRAVEL_LIST_FAIL,
    TRAVEL_LIST_REQUEST,
    TRAVEL_LIST_SUCCESS
} from "../Constants/TravelOrdersConstants"
import axios from "../../api/axios";

// TRAVEL LIST
export const listTravel = () => async (dispatch) => {
    try {
        dispatch({ type: TRAVEL_LIST_REQUEST })
        const { data } = await axios.get("/api/TravelOrders");
        dispatch({ type: TRAVEL_LIST_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: TRAVEL_LIST_FAIL,
            payload: message
        });
    }
}

// DELETE TRAVEL
export const deleteTravel = (id) => async (dispatch) => {
    try {
        dispatch({ type: TRAVEL_DELETE_REQUEST })
        await axios.delete(`/api/TravelOrders/${id}`);
        dispatch({ type: TRAVEL_DELETE_SUCCESS })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: TRAVEL_DELETE_FAIL,
            payload: message
        });
    }
}

// CREATE TRAVEL
export const createTravel = (employeeId, carsId, date, mileage, route) => async (dispatch) => {
    try {
        dispatch({ type: TRAVEL_CREATE_REQUEST })

        const { data } = await axios.post(
            `/api/TravelOrders`,
            { employeeId, carsId, date, mileage, route }
        );
        dispatch({ type: TRAVEL_CREATE_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: TRAVEL_CREATE_FAIL,
            payload: message
        });
    }
}

// EDIT TRAVEL
export const editTravel = (id) => async (dispatch) => {
    try {
        dispatch({ type: TRAVEL_EDIT_REQUEST })
        const { data } = await axios.get(`/api/TravelOrders/${id}`);
        dispatch({ type: TRAVEL_EDIT_SUCCESS, payload: data })
    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: TRAVEL_EDIT_FAIL,
            payload: message
        });
    }
}