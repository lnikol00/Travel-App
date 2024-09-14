import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { thunk } from "redux-thunk";
import { carsListReducer, carsCreateReducer, carsDeleteReducer, } from "./Reducers/CarsReducers";
import { driversCreateReducer, driversDeleteReducer, driversListReducer } from "./Reducers/DriverReducers";
import { travelCreateReducer, travelDeleteReducer, travelListReducer } from "./Reducers/TravelOrdersReducers";

const reducers = combineReducers({
    carsList: carsListReducer,
    carsDelete: carsDeleteReducer,
    carsCreate: carsCreateReducer,
    driversList: driversListReducer,
    driversDelete: driversDeleteReducer,
    driversCreate: driversCreateReducer,
    travelList: travelListReducer,
    travelDelete: travelDeleteReducer,
    travelCreate: travelCreateReducer,
})

const middleware = [thunk]


const store = configureStore({
    reducer: reducers,
    middleware: getDefaultMiddleware =>
        getDefaultMiddleware().concat(middleware),
})

export default store