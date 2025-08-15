using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamazon.Cargo.DataAcces.Abstract;
using Zamazon.Cargo.DataAcces.Context;
using Zamazon.Cargo.DataAcces.Repositories;
using Zamazon.Cargo.Entity.Concrete;

namespace Zamazon.Cargo.DataAcces.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
