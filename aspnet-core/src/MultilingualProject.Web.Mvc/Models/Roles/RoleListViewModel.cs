using System.Collections.Generic;
using MultilingualProject.Roles.Dto;

namespace MultilingualProject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
