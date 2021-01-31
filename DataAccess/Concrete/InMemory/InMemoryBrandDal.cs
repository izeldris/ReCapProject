using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand { BrandId = 1, BrandName = "Mercedes-Benz" },
                new Brand { BrandId = 2, BrandName = "Seat" },
                new Brand { BrandId = 3, BrandName = "Audi" },
                new Brand { BrandId = 4, BrandName = "Volswagen" },
                new Brand { BrandId = 5, BrandName = "BMW" }
            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            Brand brandsToUpdate = _brands.SingleOrDefault(btu => btu.BrandId == brand.BrandId);
            brandsToUpdate.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            Brand brandsToDelete = _brands.SingleOrDefault(btd => btd.BrandId == brand.BrandId);
            _brands.Remove(brandsToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }
    }   
                          
 }

