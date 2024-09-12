import {
    TRAVEL_LIST_REQUEST,
    TRAVEL_LIST_SUCCESS,
    TRAVEL_LIST_FAIL,
    TRAVEL_DELETE_REQUEST,
    TRAVEL_DELETE_SUCCESS,
    TRAVEL_DELETE_FAIL,
    TRAVEL_CREATE_REQUEST,
    TRAVEL_CREATE_SUCCESS,
    TRAVEL_CREATE_FAIL,
    TRAVEL_CREATE_RESET,
    TRAVEL_EDIT_REQUEST,
    TRAVEL_EDIT_SUCCESS,
    TRAVEL_EDIT_FAIL
} from "../Constants/TravelOrdersConstants";

//TRAVEL LIST
export const travelListReducer = (state = { travelOrders: [] }, action) => {
    switch (action.type) {
        case TRAVEL_LIST_REQUEST:
            return { loading: true, travelOrders: [] };
        case TRAVEL_LIST_SUCCESS:
            return { loading: false, travelOrders: action.payload };
        case TRAVEL_LIST_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// DELETE TRAVEL
export const travelDeleteReducer = (state = {}, action) => {
    switch (action.type) {
        case TRAVEL_DELETE_REQUEST:
            return { loading: true };
        case TRAVEL_DELETE_SUCCESS:
            return { loading: false, success: true };
        case TRAVEL_DELETE_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}

// CREATE TRAVEL
export const travelCreateReducer = (state = {}, action) => {
    switch (action.type) {
        case TRAVEL_CREATE_REQUEST:
            return { loading: true };
        case TRAVEL_CREATE_SUCCESS:
            return { loading: false, success: true, travelOrder: action.payload };
        case TRAVEL_CREATE_FAIL:
            return { loading: false, error: action.payload };
        case TRAVEL_CREATE_RESET:
            return {};
        default:
            return state;
    }
}

// EDIT TRAVEL
export const travelEditReducer = (state = { travelOrders: [] }, action) => {
    switch (action.type) {
        case TRAVEL_EDIT_REQUEST:
            return { loading: true };
        case TRAVEL_EDIT_SUCCESS:
            return { loading: false, travelOrders: action.payload };
        case TRAVEL_EDIT_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
}