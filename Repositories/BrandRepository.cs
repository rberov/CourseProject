using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {

        public override void Save(Brand brand)
        {
            if (brand.ID == 0)
            {
                base.Create(brand);
            }
            else
            {
                base.Update(brand, item => item.ID == brand.ID);
            }
        }

    }
}
