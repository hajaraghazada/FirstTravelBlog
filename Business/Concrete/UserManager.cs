using Business.Abstract;
using Core.DataRepositories.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager(IUserDal userDal) : IUserService
    {
        private readonly IUserDal _userDal=userDal;
       
        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult($"the user added successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while adding the user...");
            }
            
        }

        public IResult Delete(User user)
        {
            try
            {
                //_userDal.Delete(user);
                user.IsActive = false;
                _userDal.Update(user);
                return new SuccessResult($"the user deleted successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while deleting the user...");
            }

           
        }

        public IDataResult<User> Get(int id)
        {
           var user= _userDal.Get(p => p.Id == id && p.IsActive);
            if (user != null)
            {
                return new SuccessDataResult<User>(user, "User found successfuly! ");
            }
            return new ErrorDataResult<User>("User not found...");
        }

        public IDataResult<List<User>> GetAll()
        {
          var user= _userDal.GetAll(p=>p.IsActive);
            if (user.Count > 0)
            {
                return new SuccessDataResult<List<User>>(user, "Users retrieved successfuly! ");
            }
            return new ErrorDataResult<List<User>>("No Users found...");
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult($"the user updated successfully! ");
            }
            catch
            {
                return new ErrorResult($"An error occurred while updating the user...");
            }
            
        }
    }
}
