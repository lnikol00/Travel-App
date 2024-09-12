import './global/global.css';
import Header from './components/header/Header';
import NotFound from './pages/not-found/NotFound';
import Home from './pages/home/Home'
import Cars from './pages/cars/Cars'
import TravelOrders from './pages/travel/TravelOrders'
import Drivers from './pages/drivers/Drivers'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import CreateCar from './pages/cars/CreateCar';
import UpdateCars from './pages/cars/UpdateCars';
import CreateDriver from './pages/drivers/CreateDriver';
import CreateTravelOrder from './pages/travel/CreateTravelOrder';


function App() {
  return (
    <div className="App">
      <Router>
        <Header />
        <div className='main-container'>
          <Routes>
            <Route index element={<Home />} />
            <Route path='drivers' element={<Drivers />} />
            <Route path='create-drivers' element={<CreateDriver />} />
            <Route path='cars' element={<Cars />} />
            <Route path='create-cars' element={<CreateCar />} />
            <Route path='update-car/:id' element={<UpdateCars />} />
            <Route path='travel-orders' element={<TravelOrders />} />
            <Route path='create-travel-orders' element={<CreateTravelOrder />} />
            <Route path='*' element={<NotFound />} />
          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
