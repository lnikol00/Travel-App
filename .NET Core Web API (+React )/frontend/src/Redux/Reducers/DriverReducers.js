import {
    DRIVERS_LIST_REQUEST,
    DRIVERS_LIST_SUCCESS,
    DRIVERS_LIST_FAIL,
    DRIVERS_DELETE_REQUEST,
    DRIVERS_DELETE_SUCCESS,
    DRIVERS_DELETE_FAIL,
    DRIVERS_CREATE_REQUEST,
    DRIVERS_CREATE_SUCCESS,
    DRIVERS_CREATE_FAIL,
    DRIVERS_CREATE_RESET,
} from "../Constants/DriverConstants";

//DRIVERS LIST
export const driversListReducer = (state = { drivers: [] }, action) => {
    switch (action.type) {
        case DRIVERS_LIST_REQUEST:
            return { loading: true, drivers: [] };
        case DRIVERS_LIST_SUCCESS:
            return { loading: false, drivers: action.payload };
        case DRIVERS_LIST_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// DELETE DRIVERS
export const driversDeleteReducer = (state = {}, action) => {
    switch (action.type) {
        case DRIVERS_DELETE_REQUEST:
            return { loading: true };
        case DRIVERS_DELETE_SUCCESS:
            return { loading: false, success: true };
        case DRIVERS_DELETE_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// CREATE DRIVERS
export const driversCreateReducer = (state = {}, action) => {
    switch (action.type) {
        case DRIVERS_CREATE_REQUEST:
            return { loading: true };
        case DRIVERS_CREATE_SUCCESS:
            return { loading: false, success: true, driver: action.payload };
        case DRIVERS_CREATE_FAIL:
            return { loading: false, error: action.payload };
        case DRIVERS_CREATE_RESET:
            return {};
        default:
            return state;
    }
}