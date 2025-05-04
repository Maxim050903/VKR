using static Core.Types.Types;

namespace Core.Models
{
    public class _Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IdBoss { get; set; }
        public Guid IdAgragete { get; set; } //?
        public TaskType Type { get; set; }
        public Guid idUorD { get; set; }

        private _Task(Guid id,string Name, Guid IdBoss, Guid IdAgragete,TaskType Type, Guid idUorD)
        {
            this.Id = id;
            this.Name = Name;
            this.IdBoss = IdBoss;
            this.IdAgragete = IdAgragete;
            this.Type = Type;
            this.idUorD = idUorD;
        }

        public static (string error, _Task task) CreateTask(Guid id,string Name, Guid IdBoss, Guid IdAgragete, TaskType Type, Guid idUorD)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(Name);

            if (error == "None")
            {
                var task = new _Task(id,Name, IdBoss, IdAgragete, Type, idUorD);
                return (error,task);
            }
            else
            {
                return (error, null);
            }
        }

    }
}
