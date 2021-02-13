using System;
using System.Linq;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
          
        static void Main(string[] args)
        {
            //GetAllTest();
            GetCarDetailsTest();
            //AddCarTest(_carService);







            //**********************************************************************************************************************************
            //**********************************************************************************************************************************

            ICarService _carService = new CarManager(new EfCarDal());
            IBrandService _brandService = new BrandManager(new EfBrandDal());
            IColorService _colorService = new ColorManager(new EfColorDal());

            










        }

        private static void AddCarTest(ICarService _carService)
        {
            Car car = new Car
            {
                Id = 8,
                BrandId = 4,
                ColorId = 3,
                ModelYear = 2017,
                DailyPrice = 229,
                Descriptions = "2.0cc BiTurbo 4WD Şehir ve Arazi İçin Uygun",
                ModelName = "Q8"
            };
            _carService.Add(car);

            Console.WriteLine("Yeni Kayıt Başarıyla Eklendi. ------> " + car.ModelName);
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ModelName + "  <----------- % ---------->  " + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Descriptions, car.DailyPrice, car.ModelYear);
            }
        }
    }
}
