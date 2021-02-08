using Core.Interface;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Classes
{
    public class Scopes
    {
        private IAdminRepository _admin;
        private IUserRepository _user;
        public Scopes(IAdminRepository admin , IUserRepository user)
        {
            _admin = admin;
            _user = user;
        }

        public bool ExistRolePermissions(int roleid , int permissionid)
        {
            return _admin.ExistRolePermission(roleid, permissionid);
        }

        public string GetRoleName(string name)
        {
            return _user.GetRoleNameByKeyName(name);
        }

        public bool ExistDegreeCountry(int degreeid , int countryid)
        {
            return _admin.ExistDegreeCountry(degreeid, countryid);
        }

        public bool ExistLangCountry(int langid , int countryid)
        {
            return _admin.ExistLangCountry(langid, countryid);
        }

        public List<int> GetLangId(List<Language> languages)
        {
            return _admin.GetLangId(languages);
        }


        public bool NeedVisa(int countryId)
        {
            return _admin.NeedVisa(countryId);
        }


        public int GetUserId(string name)
        {
            return _user.GetUserIdByKeyName(name);
        }
        
    }
}
