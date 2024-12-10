using System;
using Microsoft.EntityFrameworkCore;
using StradaAPI.Model;
using StradaAPI.Repositories;

namespace StradaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || _context.Users.Any(u => u.Email == user.Email))
            {
                throw new ArgumentException("Email is required and must be unique.");
            }

            foreach (var employment in user.Employments)
            {
                if (employment.StartDate >= employment.EndDate)
                {
                    throw new ArgumentException("Employment EndDate should be greater than StartDate.");
                }
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserById(int id)
        {
            var user = _context.Users
                .Include(u => u.Address)
                .Include(u => u.Employments)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return user;
        }

        public User UpdateUser(int id, User updatedUser)
        {
            var user = _context.Users
                .Include(u => u.Employments)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            if (_context.Users.Any(u => u.Email == updatedUser.Email && u.Id != id))
            {
                throw new ArgumentException("Email must be unique.");
            }

            foreach (var employment in updatedUser.Employments)
            {
                if (employment.StartDate >= employment.EndDate)
                {
                    throw new ArgumentException("Employment EndDate should be greater than StartDate.");
                }
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Address = updatedUser.Address;
            user.Employments = updatedUser.Employments;

            _context.SaveChanges();
            return user;
        }
    }


}

