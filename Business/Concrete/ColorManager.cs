using Business.Abstract;
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

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Renk Başarıyla Eklendi." + color.ColorName);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk Başarıyla Silindi" + color.ColorName);
        }

        public List<Color> GetAll()
        {
            Console.WriteLine("------------------- Sistemde Kayıtlı Renkler ------------------- ");
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            Console.WriteLine("Girilen Renk Kodu  : {0}" , id);
            return _colorDal.Get();
        }

        public void Update(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk Başarıyla Silindi" + color.ColorName);
        }
    }
}
