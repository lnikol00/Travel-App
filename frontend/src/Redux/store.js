import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { thunk } from "redux-thunk";
import { carsListReducer, carsCreateReducer, carsDeleteReducer, carsEditReducer } from "./Reducers/CarsReducers";
import { driversCreateReducer, driversDeleteReducer, driversEditReducer, driversListReducer } from "./Reducers/DriverReducers";
import { travelCreateReducer, travelDeleteReducer, travelEditReducer, travelListReducer } from "./Reducers/TravelOrdersReducers";

const reducers = combineReducers({
    carsList: carsListReducer,
    carsDelete: carsDeleteReducer,
    carsCreate: carsCreateReducer,
    carsEdit: carsEditReducer,
    driversList: driversListReducer,
    driversDelete: driversDeleteReducer,
    driversCreate: driversCreateReducer,
    driversEdit: driversEditReducer,
    travelList: travelListReducer,
    travelDelete: travelDeleteReducer,
    travelCreate: travelCreateReducer,
    travelEdit: travelEditReducer,
})

const middleware = [thunk]

const store = configureStore({
    reducer: reducers,
    middleware: getDefaultMiddleware =>
        getDefaultMiddleware().concat(middleware)
})

export default store