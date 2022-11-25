using P2_UnitTestMock.Entities;
using P2_UnitTestMock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_UnitTestMock.Controllers {
    public class CarController {
        private ICarService _carService;

        // konstruktor z wstrzykiwaniem zależności
        public CarController(ICarService carService) {
            _carService = carService;
        }

        // zwraca obiekt Car, na podstawie id pojazdu
        public Car GetCar(int carId) {
            return _carService.GetCar(carId);
        }

        // metoda, która zwraca obiekt numeryczny, jako wszystkie pojazdy
        public IEnumerable<Car> GetCars() {
            return _carService.GetCars();
        }

        // zwraca obiekt Car na podstawie numeru rejestracyjnego
        public Car GetCarByRegisterNumber(string registerNumber) {
            return _carService.GetCarByRegisterNumber(registerNumber);
        }

        // zwraca przebiego pojazdu, na podstawie jego id
        public int GetCarCource(int carId) {
            return _carService.GetCarCource(carId);
        }

        // zwraca listę modele pojazdu na podstawie podanej marki
        public IEnumerable<string> GetModelsByMark(string mark) {
            return _carService.GetModelsByMark(mark);
        }
    }
}
