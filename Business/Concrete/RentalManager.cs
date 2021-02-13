using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate>DateTime.Now)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(ren => ren.Id == id), Messages.ItemsListed);
        }

        public IDataResult<List<CarRentDetailDTO>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentDetailDTO>>(_rentalDal.GetRentalDetails(), Messages.ItemsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
