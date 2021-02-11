using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),message:"Ürün getirildi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Add(Car car,Brand brand)
        {
            if (car.DailyPrice>0 && brand.BrandName.Length>2)
            {
                _carDal.Add(car);
               return new SuccessResult("Ürün eklendi");
            }
            else
            {
                return new ErrorResult("Ürün Eklenemedi");
            }
            
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
           return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),"Ürünler getirildi"); 
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Ürün Silindi");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Ürünle güncellendi");
        }
    }
}
