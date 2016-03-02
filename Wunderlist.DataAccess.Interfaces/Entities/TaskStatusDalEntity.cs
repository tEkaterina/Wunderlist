namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class TaskStatusDalEntity : IDalEntity
    {
        public TaskStatusDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
    }
}
