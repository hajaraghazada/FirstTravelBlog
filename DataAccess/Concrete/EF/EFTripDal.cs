﻿using Core.DataRepositories.Concrete;
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
    public class EFTripDal(DbContext context) : BaseRepository<Trip, DbContext>(context), ITripDal
    {
    }
}
