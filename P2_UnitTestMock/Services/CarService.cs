using P2_UnitTestMock.Entities;
using P2_UnitTestMock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_UnitTestMock.Services {
    public class CarService {
        private AppDbContext _dbContext;
        private ICarService _carService;

        // konstruktor z wstrzykiwaniem zależności
        public CarService(AppDbContext appDbContext, ICarService carService) {
            _dbContext = appDbContext;
            _carService = carService;
        }

        // zwraca obiekt Car, na podstawie id pojazdu
        public Car GetCar(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).FirstOrDefault();
        }

        // metoda, która zwraca obiekt numeryczny, jako wszystkie pojazdy
        public IEnumerable<Car> GetCars() {
            return _dbContext.Cars;
        }

        // zwraca obiekt Car na podstawie numeru rejestracyjnego
        public Car GetCarByRegisterNumber(string registerNumber) {
            return _dbContext.Cars.Where(x => x.RegisterNumber == registerNumber).FirstOrDefault();
        }

        // zwraca przebiego pojazdu, na podstawie jego id
        public int GetCarCource(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).Select(y => y.Course).FirstOrDefault();
        }

        // zwraca listę modele pojazdu na podstawie podanej marki
        public IEnumerable<string> GetModelsByMark(string mark) {
            return _dbContext.Cars.Where(x => x.Mark == mark).Select(y => y.Model).Distinct();
        }
    }
}
