﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,  string message):base(data, true,message)
        {
            
        }
        public SuccessDataResult(T data):base (data, true)
        {

        }
        public SuccessDataResult(string message):base(default,true, message)
        {

        }
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}

