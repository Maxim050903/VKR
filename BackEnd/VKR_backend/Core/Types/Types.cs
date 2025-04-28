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
            BigBoss = 2,
            Boss = 1,
            Worker = 0,
            Admin = 3   
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
