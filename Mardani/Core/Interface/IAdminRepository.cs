using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface
{
    public interface IAdminRepository
    {
        #region Permission

        List<Permission> GetAllPermissions();

        Permission GetPermission(int id);

        void AddPermission(Permission permission);

        void EditPermission(int id, string name);

        void DeletePermission(int id);

        #endregion

        #region Role

        List<Role> GetAllRoles();

        Role GetRole(int id);

        void AddRole(Role role);

        void EditRole(int id, string name);

        void DeleteRole(int id);

        #endregion

        #region RolePermission

        bool ExistRolePermission(int roleid, int permissionid);
        void AddRolePermission(RolePermission rolePermission);
        void DeleteAllRolePermission(int roleid);

        #endregion

        #region Degree

        List<Degree> GetAllDegrees();
        Degree GetDegree(int id);
        void AddDegree(Degree degree);
        void EditDegree(int id, string name);
        void DeleteDegree(int id);

        #endregion

        #region SpentMoney
        List<SpentMoney> GetAllSpentMoney();
        SpentMoney GetSpent(int id);
        void AddSpentMoney(SpentMoney spentMoney);
        void EditSpentMoney(int id, int money);
        void DeleteSpentMoney(int id);
        #endregion

        #region Country

        List<Country> GetAllCountries();

        List<Country> ReslutCountry(int budget , int degree , int lang , int ielts,bool visa , int percent);

        Country GetCountry(int id);

        void AddCountry(Country country);

        void EditCountry(int id,int budget,int lang , string name , string imagename , bool visa , string desc,int ielts);

        void DeleteCountry(int id);

        bool NeedVisa(int countryId);

        #endregion

        #region DegreeCountry

        bool ExistDegreeCountry(int degree, int countryid);
        void AddDegreeCounrty(DegreeCountry degreeCountryid);
        void DeleteAllDegreeCountry(int countryid);
        List<DegreeCountry> GetDegreeCountries(int countryid);

        #endregion

        #region Language

        List<Language> GetAllLanguages();

        #endregion

        #region LangCountry

        bool ExistLangCountry(int langid, int countryid);

        void AddLangCountry(LangCountry langCountry);

        void DeleteAllLangCountry(int id);

        List<int> GetLangId(List<Language> languages);

        List<LangCountry> GetLangCountries(int countryid);
        #endregion


        
    }
}
