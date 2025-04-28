using static Core.Types.Types;

namespace VKR_backend.DTOs
{
    public record UserCreateResponse
    (
        string IndividualNumber,
        string Name ,
        string Surname ,
        string Otchestvo ,
        string Password ,
        Guid IdDepartment,
        Guid IdBoss,
        Roles Role            
    );

    public record DepartmentCreateResponse
    (
        string Name,
        Guid IdBoss,
        List<Guid> Members
    );

    public record TaskCreateResponse
    (
        string Name,
        Guid IdBoss,
        Guid IdAgregate,
        string Description,
        TaskType tasktype,
        Guid IdForHim
    );

    public record AgrigateCreateResponse
    (
        Guid IdManufacture,
        string Name,
        string ManufactureName
    );

    public record ContractCreateResponse
    (
        string Name,
        Guid IdManufacture,
        DateOnly DateStart,
        DateOnly DateFinish,
        string Description
    );

    public record CertificateCreateResponse
    (
        string Organization,
        string Description
    );

    public record OrganizationCreateResponse
    (
        string Name
    );
}
