using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using NUnit.Framework;
using P2_UnitTestMock.Controllers;
using P2_UnitTestMock.Entities;
using P2_UnitTestMock.Model;
using P2_UnitTestMock.Services;

namespace UnitTest {
    [TestFixture]
    public class CarTest {
        public Mock<ICarService> carMock = new Mock<ICarService>();
        
        [Test]
        public void GetCar_GetOneCar_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCar(1)).Returns(car);
            CarController carController = new CarController(carMock.Object);
            Car result = carController.GetCar(1);
            Assert.AreEqual(result, car);
        }

        [Test]
        public void GetCar_GetNull_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCar(2)).Returns<Car>(null);
            CarController carController = new CarController(carMock.Object);
            Car result = carController.GetCar(2);
            Assert.AreNotEqual(result, car);
        }

        [Test]
        public void GetCars_GetCount_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            Car car2 = new Car() {
                Id = 2,
                Mark = "Suzuki",
                Model = "Baleno",
                Course = 55444,
                RegisterNumber = "KLI 65656"
            };

            Car car3 = new Car() {
                Id = 3,
                Mark = "Bugatti",
                Model = "Chiron ",
                Course = 2541,
                RegisterNumber = "KNS 00011"
            };

            carMock.Setup(x => x.GetCars()).Returns(new List<Car>{car, car2, car3 });
            CarController carController = new CarController(carMock.Object);
            IEnumerable<Car> result = carController.GetCars();
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void GetCarByRegisterNumber_GetOneCar_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCarByRegisterNumber("KN 12345")).Returns(car);
            CarController carController = new CarController(carMock.Object);
            Car result = carController.GetCarByRegisterNumber("KN 12345");
            Assert.AreEqual(result, car);
        }

        [Test]
        public void GetCarByRegisterNumber_GetNull_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCarByRegisterNumber("KGR ANS1")).Returns<Car>(null);
            CarController carController = new CarController(carMock.Object);
            Car result = carController.GetCarByRegisterNumber("KGR ANS1");
            Assert.AreNotEqual(result, car);
        }
        
        [Test]
        public void GetCarCource_GetValue_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCarCource(1)).Returns(123000);
            CarController carController = new CarController(carMock.Object);
            int result = carController.GetCarCource(1);
            Assert.AreEqual(result, car.Course);
        }

        [Test]
        public void GetCarCource_GetZero_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            carMock.Setup(x => x.GetCarCource(2)).Returns(0);
            CarController carController = new CarController(carMock.Object);
            int result = carController.GetCarCource(2);
            Assert.AreNotEqual(result, car.Course);
        }

        [Test]
        public void GetCarCource_GetZero_ShouldNotCorrect() {
            Car car = new Car() {};

            carMock.Setup(x => x.GetCarCource(1)).Returns(0);
            CarController carController = new CarController(carMock.Object);
            int result = carController.GetCarCource(1);
            Assert.AreEqual(result, car.Course);
        }

        [Test]
        public void GetModelsByMark_GetCount_ShouldCorrect() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            Car car2 = new Car() {
                Id = 2,
                Mark = "Fiat",
                Model = "Freemont",
                Course = 9991,
                RegisterNumber = "KTT 8722"
            };

            Car car3 = new Car() {
                Id = 3,
                Mark = "Fiat",
                Model = "Freemont",
                Course = 54680,
                RegisterNumber = "RJS PW33"
            };

            carMock.Setup(x => x.GetModelsByMark("Fiat")).Returns(new List<string>{
                "Seicento", "Freemont"});
            CarController carController = new CarController(carMock.Object);
            IEnumerable<string> result = carController.GetModelsByMark("Fiat");
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetModelsByMark_GetCount_ShouldNotCorrect() {
            Car car2 = new Car() {
                Id = 2,
                Mark = "Fiat",
                Model = "Freemont",
                Course = 9991,
                RegisterNumber = "KTT 8722"
            };

            Car car3 = new Car() {
                Id = 3,
                Mark = "Fiat",
                Model = "Freemont",
                Course = 54680,
                RegisterNumber = "RJS PW33"
            };

            carMock.Setup(x => x.GetModelsByMark("Fiat")).Returns(new List<string>{ "Freemont" });
            CarController carController = new CarController(carMock.Object);
            IEnumerable<string> result = carController.GetModelsByMark("Fiat");
            Assert.AreNotEqual(2, result.Count());
        }
    }
}