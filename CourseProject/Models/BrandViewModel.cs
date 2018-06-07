using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class BrandViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }

        public BrandViewModel(Brand brand)
        {
            ID = brand.ID;
            Name = brand.Name;
            CountryOfOrigin = brand.CountryOfOrigin;
        }

    }

    public class BrandsViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }

        public List<BrandViewModel> brands;

        public BrandsViewModel()
        {
            brands = new List<BrandViewModel>();
        }

        public BrandsViewModel(Brand brand)
        {
            ID = brand.ID;
            Name = brand.Name;
            CountryOfOrigin = brand.CountryOfOrigin;
        }

        public BrandsViewModel(List<Brand> dbBrands)
            : this()
        {
            foreach (Brand brand in dbBrands)
            {
                BrandViewModel brandViewModel = new BrandViewModel(brand);
                brands.Add(brandViewModel);
            }
        }

    }
}