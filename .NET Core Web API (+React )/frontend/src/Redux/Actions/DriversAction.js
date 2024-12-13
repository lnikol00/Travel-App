
import {
    DRIVERS_CREATE_FAIL,
    DRIVERS_CREATE_REQUEST,
    DRIVERS_CREATE_SUCCESS,
    DRIVERS_DELETE_FAIL,
    DRIVERS_DELETE_REQUEST,
    DRIVERS_DELETE_SUCCESS,
    DRIVERS_LIST_FAIL,
    DRIVERS_LIST_REQUEST,
    DRIVERS_LIST_SUCCESS
} from "../Constants/DriverConstants"
import axios from "../../api/axios";

// DRIVERS LIST
export const listDrivers = () => async (dispatch) => {
    try {
        dispatch({ type: DRIVERS_LIST_REQUEST })
        const { data } = await axios.get("/api/Employee");
        dispatch({ type: DRIVERS_LIST_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;

        dispatch({
            type: DRIVERS_LIST_FAIL,
            payload: message
        });
    }
}

// DELETE DRIVERS
export const deleteDrivers = (id) => async (dispatch) => {
    try {
        dispatch({ type: DRIVERS_DELETE_REQUEST })
        await axios.delete(`/api/Employee/${id}`);
        dispatch({ type: DRIVERS_DELETE_SUCCESS })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: DRIVERS_DELETE_FAIL,
            payload: message
        });
    }
}

// CREATE DRIVERS
export const createDrivers = (name, lastName) => async (dispatch) => {
    try {
        dispatch({ type: DRIVERS_CREATE_REQUEST })

        const { data } = await axios.post(
            `/api/Employee`,
            { name, lastName }
        );
        dispatch({ type: DRIVERS_CREATE_SUCCESS, payload: data })

    } catch (error) {
        const message =
            error.response && error.response.data ? error.response.data : error.message;
        dispatch({
            type: DRIVERS_CREATE_FAIL,
            payload: message
        });
    }
}

