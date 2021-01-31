using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars=new List<Car>(){new Car()
            {
                Id = 1,BrandId = "BMW",ColorId = "Beyaz",DailyPrice = 100000,Description = "En yeni model araba 1",ModelYear = "2005"
            },
                new Car()
                {
                Id = 2,BrandId ="Mercedes",ColorId = "Mavi",DailyPrice = 200000,Description = "En yeni model araba 2",ModelYear = "2020"
            },
                new Car()
            {
                Id = 3,BrandId = "Audi",ColorId = "Beyaz",DailyPrice = 150000,Description = "En yeni model araba 3",ModelYear = "2015"
            },
                new Car()
            {
                Id = 4,BrandId ="Toyota",ColorId ="Siyah",DailyPrice = 50000,Description = "En yeni model araba 4",ModelYear = "1999"
            },
                new Car()
            {
                Id = 5,BrandId ="Renault",ColorId = "Kırmızı",DailyPrice = 178000,Description = "En yeni model araba 5",ModelYear = "2018"
            }
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
