using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class CarsViewModel
    {

        public int ID { get; set; }
        public string Model { get; set; }
        public int Brand { get; set; }
        public Brand CarBrand { get; set; }
        public string Color { get; set; }
        public int HP { get; set; }

        public CarsViewModel(Car car)
        {
            ID = car.ID;
            Model = car.Model;
            Brand = car.Brand;
            HP = car.HP;
            Color = car.Color;
            CarBrand = car.Brand1;
        }

    }

    public class CarViewModel
    {

        public int ID { get; set; }
        public string Model { get; set; }
        public int Brand { get; set; }
        public string Color { get; set; }
        public int HP { get; set; }
        public Brand CarBrand { get; set; }

        public List<CarsViewModel> cars;

        public CarViewModel()
        {
            cars = new List<CarsViewModel>();
        }

        public CarViewModel(Car car)
        {
            ID = car.ID;
            Model = car.Model;
            Brand = car.Brand;
            HP = car.HP;
            Color = car.Color;
            CarBrand = car.Brand1;
        }


        public CarViewModel(List<Car> dbCars)
            : this()
        {
            foreach (Car car in dbCars)
            {
                CarsViewModel carViewModel = new CarsViewModel(car);
                cars.Add(carViewModel);
            }
        }

    }
}