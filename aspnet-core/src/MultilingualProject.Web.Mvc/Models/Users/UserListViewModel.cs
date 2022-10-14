using System.Collections.Generic;
using MultilingualProject.Roles.Dto;

namespace MultilingualProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
