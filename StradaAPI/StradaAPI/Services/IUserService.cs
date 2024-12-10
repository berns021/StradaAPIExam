using System;
using StradaAPI.Model;

namespace StradaAPI.Services
{
	public interface IUserService
	{
        User CreateUser(User user);
        User GetUserById(int id);
        User UpdateUser(int id, User user);
    }
}

