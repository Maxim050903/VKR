namespace Core.Types
{
    public class Types
    {
        [Flags]
        public enum RequestType
        {
            Edit = 1,
            Delete = 2,
            ChangeDepartment = 3,
            ChangePassword = 4
        };

        [Flags]
        public enum TaskType
        {
            ForUser = 1,
            ForDepartment = 2
        };

        [Flags]
        public enum Roles
        {
            Director = 3,
            Boss = 2,
            Worker = 1,
            Admin = 0   
        };

        [Flags]
        public enum ExceptionType
        {
            None,
            NameFaild,
            UnknownError
        };
    }
}
