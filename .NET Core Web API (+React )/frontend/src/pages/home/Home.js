import React, { useEffect } from 'react'
import styles from "../../styles/home/home.module.css"
import Error from '../../components/messages/Error/Error';
import Loading from '../../components/messages/Loading/Loading';
import { BarChart, XAxis, YAxis, Tooltip, Legend, CartesianGrid, Bar } from 'recharts';
import { useDispatch, useSelector } from "react-redux"
import { listTravel } from '../../Redux/Actions/TravelOrdersAction';


function Home() {

    const dispatch = useDispatch()

    const travelList = useSelector((state) => state.travelList);
    const { loading, error, travelOrders } = travelList;

    useEffect(() => {
        dispatch(listTravel());
    }, [dispatch])

    const groupedDataDriver = travelOrders.reduce((acc, order) => {
        const existing = acc.find(item => item.name === order.name);
        if (existing) {
            existing.trips += 1;
        } else {
            acc.push({ name: order.name, trips: 1 });
        }
        return acc;
    }, []);

    const groupedDataCar = travelOrders.reduce((acc, order) => {
        const existing = acc.find(item => item.brand === order.brand);
        if (existing) {
            existing.mileage += order.mileage;
        } else {
            acc.push({ brand: order.brand, mileage: order.mileage });
        }
        return acc;
    }, []);

    return (
        <div className={styles.mainContainer}>
            {loading && <Loading />}
            {error && <Error>{error}</Error>}
            <div className={styles.chartContainer}>
                <h2>Driver with most Travel Orders</h2>
                <BarChart
                    width={500}
                    height={300}
                    data={groupedDataDriver}
                    margin={{
                        top: 5,
                        right: 30,
                        left: 20,
                        bottom: 5,
                    }}
                    barSize={20}
                >
                    <XAxis dataKey="name" scale="point" padding={{ left: 10, right: 10 }} />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <CartesianGrid strokeDasharray="3 3" />
                    <Bar dataKey="trips" fill="#8884d8" background={{ fill: '#eee' }} />
                </BarChart>
            </div>
            <div className={styles.chartContainer}>
                <h2> Car with biggest mileage</h2>
                <BarChart
                    width={500}
                    height={300}
                    data={groupedDataCar}
                    margin={{
                        top: 5,
                        right: 30,
                        left: 20,
                        bottom: 5,
                    }}
                    barSize={20}
                >
                    <XAxis dataKey="brand" scale="point" padding={{ left: 10, right: 10 }} />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <CartesianGrid strokeDasharray="3 3" />
                    <Bar dataKey="mileage" fill="#8884d8" background={{ fill: '#eee' }} />
                </BarChart>
            </div>
        </div>
    )
}

export default Home
