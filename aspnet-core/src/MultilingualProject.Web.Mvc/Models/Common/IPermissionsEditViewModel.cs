using System.Collections.Generic;
using MultilingualProject.Roles.Dto;

namespace MultilingualProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}