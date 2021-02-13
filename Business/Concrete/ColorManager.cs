using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            Console.WriteLine("------------------- Sistemde Kayıtlı Renkler ------------------- ");
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            if (id <= 0)
            {
                return new ErrorDataResult<Color>(Messages.ItemsListFailed);
            }
            else
            {
                Console.WriteLine("Girilen Renk Kodu  : {0}", id);
                return new SuccessDataResult<Color>(_colorDal.Get(), Messages.ItemsListed);
            }        
        }
        public IResult Update(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ItemDeleted);
        }
    }
}
