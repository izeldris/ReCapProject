using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal= carImageDal;
        }




        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }



       
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarImageId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id) 
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarImageId == id));
        }




        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }



        private IResult CheckImageLimitExceeded(int carId)
        {
            var ImageLimit = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (ImageLimit>=5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImageDal.GetAll(ci => ci.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage>{new CarImage
                {
                    CarId=id,
                    ImagePath=path,
                    ImageDate=DateTime.Now
                }
                };
            }
            return _carImageDal.GetAll(ci => ci.CarId == id);

        }
    }

}
