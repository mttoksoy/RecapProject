using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService=new CarManager(new EfCarDal(),new EfBrandDal());
            //foreach (var cars in carService.GetAll())
            //{
            //    Console.WriteLine(cars.ModelYear);
            //}
            IBrandService brandService=new BrandManager(new EfBrandDal());
            //foreach (var item in brandService.GetAll())
            //{
            //    Console.WriteLine(item.BrandName);
            //}
            carService.Add(new Car(){DailyPrice = 75000},new Brand(){BrandName = "asd"} );

            //Car updateCar=new Car(){BrandId = 5,ColorId = 3,DailyPrice = 1300,Description = "Updated yapma",ModelYear = "2013",Id = 2};
            //EfCarDal efCarDal=new EfCarDal();
            //efCarDal.Update(updateCar);

            foreach (var carDetail in carService.GetCarDetails())
            {
                Console.WriteLine(carDetail.CarName + "-" + carDetail.BrandName + "-" + carDetail.ColorName + "-" + carDetail.DailyPrice);
            }

            foreach (var carDetail in carService.GetCarsByBrandId(2))
            {
                Console.WriteLine(carDetail.CarName);
            }

            //Car carDeleted=new Car(){Id =3007 };
            //carService.Delete(carDeleted);

            IColorService color=new ColorManager(new EfColorDal());
            foreach (var colors in color.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }

            Console.ReadLine();
        }
    }
}
