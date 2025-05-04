using Core.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using static Core.Types.Types;

namespace VKR_backend.DTOs
{ 
    public record UserResponse
    (
        string Name,
        string Surname,
        string Otchestvo,
        Guid IdDepartment,
        Guid IdBoss,
        Roles Role,
        string Mail,
        string Telegram,
        string Photo
    );

    public record RequestResponseBase
    {
        Guid id;
        string Creater;
        string DepartmentName;
        RequestType RequestType;
        DateOnly DateCreate;
    }

    public record RequestResponse1 : RequestResponseBase
    {
        List<User> users;
    }

    public record RequestResponse2 : RequestResponseBase
    {
        User user;
    }

    public record RequestResponse3 : RequestResponseBase
    {
        Department department;
    }

    public record RequestResponse4 : RequestResponseBase
    {
        string NewPassword;
    }
}
