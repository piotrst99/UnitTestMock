using P2_UnitTestMock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_UnitTestMock.Services {
    public interface ICarService {
        Car GetCar(int carId);
        IEnumerable<Car> GetCars();
        Car GetCarByRegisterNumber(string registerNumber);
        int GetCarCource(int carId);
        IEnumerable<string> GetModelsByMark(string mark);
    }
}
