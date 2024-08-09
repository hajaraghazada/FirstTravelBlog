﻿using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        IResult Add(Destination destination);
        IResult Update(Destination destination);
        IResult Delete(Destination destination);

        IDataResult<Destination> Get(int id);
        IDataResult<List<Destination>> GetAll();
       
    }
}
