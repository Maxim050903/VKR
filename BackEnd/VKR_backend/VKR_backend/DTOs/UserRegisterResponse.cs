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
        string Role            
    );
}
