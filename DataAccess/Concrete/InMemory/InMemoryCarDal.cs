using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;  

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=1995,DailyPrice=62000,Description="Station-Wagon"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear=2015,DailyPrice=97600,Description="HatchBack"},
                new Car{Id=3,BrandId=3,ColorId=3,ModelYear=2012,DailyPrice=85000,Description="HatchBack"},
                new Car{Id=4,BrandId=1,ColorId=1,ModelYear=2018,DailyPrice=175000,Description="Sedan"},
                new Car{Id=5,BrandId=2,ColorId=2,ModelYear=2020,DailyPrice=66000,Description="SUV"},
                new Car{Id=6,BrandId=4,ColorId=2,ModelYear=2013,DailyPrice=125000,Description="Sedan"},
                new Car{Id=7,BrandId=2,ColorId=1,ModelYear=2021,DailyPrice=72000,Description="SUV"}

            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(ctd => ctd.Id == car.Id);
            _cars.Remove(carsToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByID(int Id)
        {
            return _cars.Where(cId => cId.Id == Id).ToList();
            
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(ctu => ctu.Id == car.Id);
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;
        }
    }
}
