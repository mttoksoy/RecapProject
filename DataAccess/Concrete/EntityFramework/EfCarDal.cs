using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, CarHireContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarHireContext context=new CarHireContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    select new CarDetailsDto
                    {
                        BrandName = b.BrandName, ColorName = co.ColorName, CarName = c.CarName,DailyPrice = c.DailyPrice,Id = c.Id
                    };
                return result.ToList();
            }

            
        }
    }
}
