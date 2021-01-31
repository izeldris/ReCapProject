using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorsDal : IColorDal  
        
    {
        List<Color> _colors;

        public InMemoryColorsDal()
        {
            _colors = new List<Color>
            {             
                new Color{ColorId=1, ColorName="White"},
                new Color{ColorId=1, ColorName="Grey"},
                new Color{ColorId=1, ColorName="Black"},
                new Color{ColorId=1, ColorName="Yellow"},
                new Color{ColorId=1, ColorName="Orange"},
                new Color{ColorId=1, ColorName="Red"},
                new Color{ColorId=1, ColorName="Pink"},
                new Color{ColorId=1, ColorName="Purple"},
                new Color{ColorId=1, ColorName="Bordeaux"},
                new Color{ColorId=1, ColorName="Brown"}
            
        };
        }

        public void Add(Color colors)
        {
            _colors.Add(colors);
        }

        public void Delete(Color colors)
        {
            Color colorsToDelete = _colors.SingleOrDefault(ctd => ctd.ColorId == colors.ColorId);
            _colors.Remove(colorsToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Update(Color colors)
        {
            Color colorsToUpdate = _colors.SingleOrDefault(ctu => ctu.ColorId == colors.ColorId);
            colorsToUpdate.ColorName = colors.ColorName; 
        }
    }
}
