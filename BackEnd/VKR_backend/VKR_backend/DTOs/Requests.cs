using static Core.Types.Types;

namespace VKR_backend.DTOs
{
    public record UserRequest
    (
        string Name
    );

    public record RequestCreateRequest
    (
        Guid IdUser,
        RequestType RequestType,
        string Description
    );
}
