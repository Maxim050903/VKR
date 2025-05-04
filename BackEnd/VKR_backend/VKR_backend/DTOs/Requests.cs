using static Core.Types.Types;

namespace VKR_backend.DTOs
{
    public record UserCreateRequest
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

    public record DepartmentCreateRequest
    (
        string Name,
        Guid IdBoss,
        List<Guid> Members
    );

    public record TaskCreateRequest
    (
        string Name,
        Guid IdBoss,
        Guid IdAgregate,
        string Description,
        TaskType tasktype,
        Guid IdForHim
    );

    public record AgrigateCreateRequest
    (
        Guid IdManufacture,
        string Name,
        string ManufactureName
    );

    public record ContractCreateRequest
    (
        string Name,
        Guid IdManufacture,
        DateOnly DateStart,
        DateOnly DateFinish,
        string Description
    );

    public record CertificateCreateRequest
    (
        string Organization,
        string Description   
    );

    public record RequestCreateRequest
    (
        RequestType RequestType,
        Guid id,
        string Description
    );

    public record OrganizationCreateRequest
    (
        string Name
    );
}
