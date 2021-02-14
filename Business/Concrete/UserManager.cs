using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.ItemGet);
        }

        public IDataResult<List<User>> GetUserById(int id)
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.Id==id),Messages.ItemGet);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata");
                return new ErrorDataResult<List<User>>(Messages.ErrorMessage);
            }
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
