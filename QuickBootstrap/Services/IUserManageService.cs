using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services
{
    public interface IUserManageService
    {
        PagedResult<UserManagePageItem> GetList(Paging paging);

        User Get(string username = "");

        bool Edit(User model);

        bool Create(User model);

        bool Delete(string username);

        bool ExistsUser(string username);
    }
}