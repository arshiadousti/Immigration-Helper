using Core.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core.Service
{
    public class UserRepository : IUserRepository
    {

        private MardaniContext _context;

        public UserRepository(MardaniContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool ExistActiveCode(string activecode)
        {
            return _context.Users.Any(x => x.ActiveCode == activecode);
        }

        public bool ExistUser(string email)
        {
            try
            {
                return _context.Users.Any(x => x.Email == email);
            }
            catch 
            {

                return false;
            }
        }

        public void ActivateUser(string code)
        {
            User user= _context.Users.FirstOrDefault(x => x.ActiveCode == code);
            user.IsActive = true;
            _context.SaveChanges();
        }

        public User GetUserByKeyName(string name)
        {
            return _context.Users.Include(x=>x.Role).FirstOrDefault(x => x.Email == name);
        }

        public bool CheckUserForLogin(string email, string password)
        {
            return _context.Users.Any(x => x.Email == email && x.Password == password);
        }

        public bool IsActive(string email)
        {
            return _context.Users.Any(x => x.Email == email && x.IsActive == true);
        }

        public int GetRoleIdByKeyName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Email == name).RoleId;
        }

        public string GetRoleNameByKeyName(string name)
        {
            return _context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == name).Role.Name;
        }

        public int GetUserIdByKeyName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Email == name).Id;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(User user , string fullname)
        {
            user.FullName = fullname;
            _context.SaveChanges();
        }

        public void AddTest(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();
        }

        public void AddTestCountry(CountryTest countryTest)
        {
            _context.CountryTests.Add(countryTest);
            _context.SaveChanges();
        }

        public List<Test> GetTestsByUser(int userid)
        {
            return _context.Tests.Include(x=>x.Language).Include(x=>x.SpentMoney).Include(x=>x.Degree).Where(x => x.UserId == userid).OrderByDescending(x=>x.Date).ToList();
        }

        public List<CountryTest> GetCountryTestsByUser(int userid)
        {
            return _context.CountryTests.Include(x=>x.Country).Where(x => x.TestId == userid).ToList();
        }

        public Test GetTest(int id)
        {
            return _context.Tests.Find(id);
        }

        public List<int> GetTestsId(int userid)
        {
            return _context.Tests.Where(x => x.UserId == userid).Select(x => x.Id).ToList();
        }

        public List<Country> GetCountriesByUser(int countrytest)
        {
            return _context.CountryTests.Include(x=>x.Country).Where(x => x.TestId == countrytest).Select(x => x.Country).ToList();
        }
    }
}
