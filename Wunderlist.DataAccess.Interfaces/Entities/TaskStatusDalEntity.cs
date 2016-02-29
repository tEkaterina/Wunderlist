namespace DAL.Interfaces.Entities
{
    public class TaskStatusDalEntity : IDalEntity
    {
        public TaskStatusDalEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}
