using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Classes
{
    public class RoleAttribue:AuthorizeAttribute , IAuthorizationFilter
    {
        private IUserRepository _user;
        private IAdminRepository _admin;
        int PermissionID = 0;

        public RoleAttribue(int PersmissionId)
        {
            PermissionID = PersmissionId;
        }


         public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string username = context.HttpContext.User.Identity.Name;
                _user = (IUserRepository)context.HttpContext.RequestServices.GetService(typeof(IUserRepository));
                _admin = (IAdminRepository)context.HttpContext.RequestServices.GetService(typeof(IAdminRepository));
                int roleID = _user.GetRoleIdByKeyName(username);

                if (!_admin.ExistRolePermission(roleID,PermissionID))
                {
                    context.Result = new RedirectResult("/Login");
                }
                
            }
            else
            {
                context.Result = new RedirectResult("/Login");
            }
        }
    }
}
