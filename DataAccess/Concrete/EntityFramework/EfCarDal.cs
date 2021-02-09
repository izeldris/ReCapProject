using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal  :EfEntityRepositoryBase<Car,ReCapCarShopContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (ReCapCarShopContext context = new ReCapCarShopContext())
            {
                var result = from cr in context.Cars
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join clr in context.Colors on
                             cr.ColorId equals clr.ColorId
                             select new CarDetailDTO { BrandName = br.BrandName, ColorName = clr.ColorName, DailyPrice = cr.DailyPrice, ModelName = cr.ModelName };
                return result.ToList();
            }
        }     
    }
}
