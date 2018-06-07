using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public class CarsRepository : BaseRepository<Car>
    {
        public override void Save(Car car)
        {
            if (car.ID == 0)
            {
                base.Create(car);
            }
            else
            {
                base.Update(car, item => item.ID == car.ID);
            }
        }
    }
}
