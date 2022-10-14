using Abp.Authorization;
using MultilingualProject.Authorization.Roles;
using MultilingualProject.Authorization.Users;

namespace MultilingualProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
