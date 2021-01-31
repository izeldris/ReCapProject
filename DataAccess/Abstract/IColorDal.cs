using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal
    {
        List<Color> GetAll();
        void Add(Color colors);
        void Update(Color colors);
        void Delete(Color colors);
    }
}
