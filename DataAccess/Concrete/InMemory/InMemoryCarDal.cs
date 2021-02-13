using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=1995,DailyPrice=620,Descriptions="Station-Wagon"}              
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

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByID(int Id)
        {
            return _cars.Where(cId => cId.Id == Id).ToList();
            
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(ctu => ctu.Id == car.Id);
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Descriptions = car.Descriptions;
        }
    }
}
