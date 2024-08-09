using Core.DataRepositories.Abstract;
using Core.DataRepositories.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    internal class EFDestinationtoTripDal(DbContext context) : BaseRepository<DestinationtoTrip, DbContext>(context), IDestinationtoTripDal
    {
    }
}
