using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace Core.Interface
{
    public interface IUserRepository
    {

        #region Accounting

        bool ExistUser(string email);
        void AddUser(User user);
        bool ExistActiveCode(string activecode);
        User GetUserByKeyName(string name);
        void ActivateUser(string code);
        bool IsActive(string email);
        bool CheckUserForLogin(string email, string password);
        int  GetRoleIdByKeyName(string name);
        string GetRoleNameByKeyName(string name);
        int GetUserIdByKeyName(string name);
        User GetUserById(int id);
        void UpdateUser(User user , string fullname);
        #endregion

        #region Test

        void AddTest(Test test);

        void AddTestCountry(CountryTest countryTest);

        List<Test> GetTestsByUser(int userid);

        List<int> GetTestsId(int userid);

        Test GetTest(int id);

        List<CountryTest> GetCountryTestsByUser(int userid);

        List<Country> GetCountriesByUser(int countrytest);

        #endregion

    }
}
