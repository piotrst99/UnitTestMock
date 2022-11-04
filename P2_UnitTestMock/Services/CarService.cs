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

        public CarService(AppDbContext appDbContext, ICarService carService) {
            _dbContext = appDbContext;
            _carService = carService;
        }

        public Car GetCar(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).FirstOrDefault();
        }

        public IEnumerable<Car> GetCars() {
            return _dbContext.Cars;
        }

        public Car GetCarByRegisterNumber(string registerNumber) {
            return _dbContext.Cars.Where(x => x.RegisterNumber == registerNumber).FirstOrDefault();
        }

        public int GetCarCource(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).Select(y => y.Course).FirstOrDefault();
        }

        public IEnumerable<string> GetModelsByMark(string mark) {
            return _dbContext.Cars.Where(x => x.Mark == mark).Select(y => y.Model).Distinct();
        }
    }
}
