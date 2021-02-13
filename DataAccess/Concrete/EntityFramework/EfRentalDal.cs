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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapCarShopContext>, IRentalDal
    {
        public List<CarRentDetailDTO> GetRentalDetails()
        {
            using (ReCapCarShopContext context = new ReCapCarShopContext())
            {
                var result = from ren in context.Rentals
                             join c in context.Cars
                             on ren.CarId equals c.Id
                             join cus in context.Customers
                             on ren.CustomerId equals cus.CustomerId
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             join us in context.Users
                             on cus.UserId equals us.Id
                             select new CarRentDetailDTO
                             {
                                 RentId = ren.Id,
                                 CarId=c.Id,
                                 CustomerId=cus.CustomerId,
                                 CarName=c.ModelName,
                                 BrandName=br.BrandName,
                                 UserName=us.FirstName + "  " + us.LastName,
                                 CustomerName=cus.CompanyName,
                                 RentDate=ren.RentDate,
                                 ReturnDate=ren.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
