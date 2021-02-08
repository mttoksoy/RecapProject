using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars=new List<Car>(){new Car()
            {
                Id = 1,BrandId = 1,ColorId =1 ,DailyPrice = 100000,Description = "En yeni model araba 1",ModelYear = "2005"
            },
                new Car()
                {
                Id = 2,BrandId =1,ColorId = 3,DailyPrice = 200000,Description = "En yeni model araba 2",ModelYear = "2020"
            },
                new Car()
            {
                Id = 3,BrandId = 2,ColorId = 2,DailyPrice = 150000,Description = "En yeni model araba 3",ModelYear = "2015"
            },
                new Car()
            {
                Id = 4,BrandId =2,ColorId =4,DailyPrice = 50000,Description = "En yeni model araba 4",ModelYear = "1999"
            },
                new Car()
            {
                Id = 5,BrandId =3,ColorId = 5,DailyPrice = 178000,Description = "En yeni model araba 5",ModelYear = "2018"
            }
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
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

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
