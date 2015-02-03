using System.Data.Entity;
using System.Linq;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public sealed class ProfileService : ServiceContext, IProfileService
    {
        public User GetUserInfo(string username = "")
        {
            return DbContext.User.FirstOrDefault(p => p.UserName == username);
        }

        public bool ChangePassword(string username = "", string newPassword = "")
        {
            var userInfo = GetUserInfo(username);

            if (userInfo == null) return false;

            userInfo.UserPwd = newPassword;
            DbContext.Entry(userInfo).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }
    }
}