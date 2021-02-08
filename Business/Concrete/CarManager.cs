using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;

        public CarManager(ICarDal carDal,IBrandDal brandDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car,Brand brand)
        {
            if (car.DailyPrice>0 && brand.BrandName.Length>2)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Ürün şartları sağlamadığı için eklenmedi.");
            }
            
        }

        public List<CarDetailsDto> GetCarDetails()
        {
           return _carDal.GetCarDetails();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
