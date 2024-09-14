import {
    CARS_LIST_REQUEST,
    CARS_LIST_SUCCESS,
    CARS_LIST_FAIL,
    CARS_DELETE_REQUEST,
    CARS_DELETE_SUCCESS,
    CARS_DELETE_FAIL,
    CARS_CREATE_REQUEST,
    CARS_CREATE_SUCCESS,
    CARS_CREATE_FAIL,
    CARS_CREATE_RESET,
} from "../Constants/CarsConstants";

//CARS LIST
export const carsListReducer = (state = { cars: [] }, action) => {
    switch (action.type) {
        case CARS_LIST_REQUEST:
            return { loading: true, cars: [] };
        case CARS_LIST_SUCCESS:
            return { loading: false, cars: action.payload };
        case CARS_LIST_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// DELETE CARS
export const carsDeleteReducer = (state = {}, action) => {
    switch (action.type) {
        case CARS_DELETE_REQUEST:
            return { loading: true };
        case CARS_DELETE_SUCCESS:
            return { loading: false, success: true };
        case CARS_DELETE_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// CREATE CARS
export const carsCreateReducer = (state = {}, action) => {
    switch (action.type) {
        case CARS_CREATE_REQUEST:
            return { loading: true };
        case CARS_CREATE_SUCCESS:
            return { loading: false, success: true, car: action.payload };
        case CARS_CREATE_FAIL:
            return { loading: false, error: action.payload };
        case CARS_CREATE_RESET:
            return {};
        default:
            return state;
    }
}
