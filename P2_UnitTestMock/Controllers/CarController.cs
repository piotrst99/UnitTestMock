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

        public CarController(ICarService carService) {
            _carService = carService;
        }

        public Car GetCar(int carId) {
            return _carService.GetCar(carId);
        }

        public IEnumerable<Car> GetCars() {
            return _carService.GetCars();
        }

        public Car GetCarByRegisterNumber(string registerNumber) {
            return _carService.GetCarByRegisterNumber(registerNumber);
        }

        public int GetCarCource(int carId) {
            return _carService.GetCarCource(carId);
        }

        public IEnumerable<string> GetModelsByMark(string mark) {
            return _carService.GetModelsByMark(mark);
        }
    }
}
