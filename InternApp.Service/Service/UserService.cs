﻿using Azure.Core;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InternApp.Service.Service
{
    public class UserService : IUserService
    {
        private InternDbContext _context;
        public UserService(InternDbContext context)
        {
            _context = context;
        }
        
        public User CreateUser(User user)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == user.CompanyId);
            if(company == null)
            {
                return user;
            }
            _context.Users.Add(user);
            company.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(Guid id)
        {
            _context.Remove(_context.Users.Single(x => x.Id == id));
            _context.SaveChanges();
        }

        public async Task<PaginationResponse<User>> GetUsers(PaginationRequest request)
        {
            PaginationResponse<User> response = new PaginationResponse<User>();
            response.ResponseList = await _context.Users.OrderBy(u => u.Id).
                Skip(Math.Max((request.PageNumber - 1) * request.PageSize, 0)).
                Take(request.PageSize).
                ToListAsync();
            response.Count = _context.Users.Count();
            return response;
        }

        public async Task<PaginationResponse<User>> GetAllUsersByCompanyId(Guid companyId)
        {
            PaginationResponse<User> response = new PaginationResponse<User>();
            response.ResponseList = await _context.Users.
                OrderBy(u => u.Id).
                Where(u => u.CompanyId == companyId).
                ToListAsync();
            response.Count = _context.Users.Count(u => u.CompanyId == companyId);
            return response;
        }

        public User UpdateUser(Guid id, User user)
        {
            User? currentUser = _context.Users.Single(u => u.Id == id);
            if(currentUser == null)
            {
                return user;
            }
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.CompanyId = user.CompanyId;
            currentUser.DateOfBirth= user.DateOfBirth;
            currentUser.Position = user.Position;
            currentUser.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();
            return user;
        }
    }
}
