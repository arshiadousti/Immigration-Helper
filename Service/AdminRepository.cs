using Core.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Classes;
using System.Security.Cryptography.X509Certificates;

namespace Core.Service
{
    public class AdminRepository : IAdminRepository
    {
        private MardaniContext _context;
        public AdminRepository(MardaniContext context)
        {
            _context = context;
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void AddDegree(Degree degree)
        {
            _context.Degrees.Add(degree);
            _context.SaveChanges();
        }

        public void AddDegreeCounrty(DegreeCountry degreeCountryid)
        {
            _context.DegreeCountries.Add(degreeCountryid);
            _context.SaveChanges();
        }

        public void AddLangCountry(LangCountry langCountry)
        {
            _context.LangCountries.Add(langCountry);
            _context.SaveChanges();
        }

        public void AddPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void AddRolePermission(RolePermission rolePermission)
        {
            _context.RolePermissions.Add(rolePermission);
            _context.SaveChanges();
        }

        public void AddSpentMoney(SpentMoney spentMoney)
        {
            _context.SpentMoney.Add(spentMoney);
            _context.SaveChanges();
        }

        

        public void DeleteAllDegreeCountry(int countryid)
        {
            List<DegreeCountry> degreeCountries = _context.DegreeCountries.Where(x => x.CountryId == countryid).ToList();
            _context.DegreeCountries.RemoveRange(degreeCountries);
            _context.SaveChanges();
        }

        public void DeleteAllLangCountry(int id)
        {
            List<LangCountry> langCountries = _context.LangCountries.Where(x => x.CountryId == id).ToList();
            _context.LangCountries.RemoveRange(langCountries);
            _context.SaveChanges();
        }

        public void DeleteAllRolePermission(int roleid)
        {
            List<RolePermission> rolePermissions = _context.RolePermissions.Where(x => x.RoleId == roleid).ToList();
            _context.RemoveRange(rolePermissions);
            _context.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            Country country= _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public void DeleteDegree(int id)
        {
            Degree degree = _context.Degrees.Find(id);
            _context.Degrees.Remove(degree);
            _context.SaveChanges();
        }

        public void DeletePermission(int id)
        {
            Permission permission = _context.Permissions.Find(id);
            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            Role role = _context.Roles.Find(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public void DeleteSpentMoney(int id)
        {
            SpentMoney spentMoney = _context.SpentMoney.Find(id);
            _context.SpentMoney.Remove(spentMoney);
            _context.SaveChanges();
        }

        public void EditCountry(int id,int budget, int lang, string name, string imagename, bool visa, string desc,int ielts)
        {
            Country country = _context.Countries.Find(id);
            country.BudgetId = budget;
            //country.DegreeId = degrre;
            //country.LangId = lang;
            country.Name = name;
            country.Image = imagename;
            country.Visa = visa;
            country.Ielts = ielts;
            country.Description = desc;
            _context.SaveChanges();

        }

        public void EditDegree(int id, string name)
        {
            Degree degree = _context.Degrees.Find(id);
            degree.Name = name;
            _context.SaveChanges();
        }

        public void EditPermission(int id, string name)
        {
            Permission permission = _context.Permissions.Find(id);

            permission.Name = name;
            _context.SaveChanges();
        }

        public void EditRole(int id, string name)
        {
            Role role = _context.Roles.Find(id);
            role.Name = name;
            _context.SaveChanges();
        }

        public void EditSpentMoney(int id, int money)
        {
            SpentMoney spentMoney = _context.SpentMoney.Find(id);
            spentMoney.Money = money;
            _context.SaveChanges();
        }

        public bool ExistDegreeCountry(int degree, int countryid)
        {
            return _context.DegreeCountries.Any(x => x.DegreeId == degree && x.CountryId == countryid);
        }

        public bool ExistLangCountry(int langid, int countryid)
        {
            return _context.LangCountries.Any(x => x.LangId == langid && x.CountryId == countryid);
        }

        public bool ExistRolePermission(int roleid, int permissionid)
        {
            return _context.RolePermissions.Any(x => x.RoleId == roleid && x.PermissionId == permissionid);
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.Include(x=>x.SpentMoney).ToList();
        }

        public List<Degree> GetAllDegrees()
        {
            return _context.Degrees.ToList();
        }

        public List<Language> GetAllLanguages()
        {
            return _context.Languages.ToList();
        }

        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.OrderByDescending(x=>x.Id).ToList();
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.OrderByDescending(x => x.Id).ToList();
        }

        public List<SpentMoney> GetAllSpentMoney()
        {
            return _context.SpentMoney.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Find(id);
        }

        public Degree GetDegree(int id)
        {
            return _context.Degrees.Find(id);
        }

        public List<DegreeCountry> GetDegreeCountries(int countryid)
        {
            return _context.DegreeCountries.Include(x=>x.Degree).Where(x => x.CountryId == countryid).ToList();
        }

        public List<LangCountry> GetLangCountries(int countryid)
        {
            return _context.LangCountries.Include(x=>x.Language).Where(x => x.CountryId == countryid).ToList();
        }

        public List<int> GetLangId(List<Language> languages)
        {
            
            return languages.Select(z => z.Id).ToList();
            
        }

        public Permission GetPermission(int id)
        {
            return _context.Permissions.Find(id);
        }

        public Role GetRole(int id)
        {
            return _context.Roles.Find(id);
        }

        public SpentMoney GetSpent(int id)
        {
            return _context.SpentMoney.Find(id);
            
        }

        public bool NeedVisa(int countryId)
        {
            return _context.Countries.Any(x => x.Id == countryId && x.Visa);
        }

        public List<Country> ReslutCountry(int budget, int degree, int lang, int ielts,bool visa , int percent)
        {
            List<int> countriesid = _context.DegreeCountries.Where(x => x.DegreeId == degree ).Select(x => x.CountryId).ToList();
            //countriesid.AddRange(_context.LangCountries.Where(x => x.LangId == lang).Select(x => x.CountryId).ToList());
            List<int> coid = _context.LangCountries.Where(x => x.LangId == lang).Select(x => x.CountryId).ToList();

            List<int> result = new List<int>();




            result = countriesid.Intersect(coid).ToList();

           // List<int> langid = _context.LangCountries.Where(x => x.LangId == lang).Select(x => x.CountryId).ToList();

            List<Country> list = new List<Country>();
            foreach (var item in result)
            {
                list.AddRange(_context.Countries.Include(x=>x.CountryTests).Where(x => x.Id == item && (visa==true?x.Visa||!x.Visa:!x.Visa) && x.BudgetId <= budget && x.Ielts <= ielts).ToList());

            }
            //List<Country> countries= _context.Countries.Include(x => x.DegreeTests).Where(x => x.BudgetId <= budget
            //    && x.LangId == lang && x.Ielts <= ielts && x.DegreeTests == degreeCountries).ToList();

            

            return list;
            //List<Country> list = new List<Country>();

            //list.AddRange(_context.DegreeTests.Where(x => x.DegreeId == degree).Select(x => x.Country).ToList());
            //list.AddRange(_context.Countries.Where(x => x.BudgetId <= budget && x.Ielts <= ielts && x.LangId == lang));

            //return (List<Country>)list.Distinct();

            //list.Add(_context.DegreeTests.Where(x => x.DegreeId == degree).Select(x => x.Country)
            //    && _context.Countries.Where(x => x.BudgetId <= budget && x.Ielts <= ielts && x.LangId == lang).ToList());


            //return _context.Countries.Where(x => x.BudgetId <= budget && x.Ielts <= ielts && x.LangId == lang &&
            //x.DegreeTests == _context.DegreeTests.Where(x => x.DegreeId == degree)).ToList();
        }
    }
}
