using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {        
           _carDal.Add(car);
            return new Result(true,Messages.ItemAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ItemsListed);
        }
        public IDataResult<List<Car>> GetAllByPrice(decimal min, decimal max)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(car=>car.DailyPrice>=min && car.DailyPrice<=max),true,Messages.ItemsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new DataResult<Car>(_carDal.Get(cid=>cid.Id==id),Messages.ItemsListed);
        }
    

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(), true, Messages.ItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == id), true, Messages.ItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(car => car.ColorId == id), Messages.ItemsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(Messages.ItemUpdated);
        }
    }
}
