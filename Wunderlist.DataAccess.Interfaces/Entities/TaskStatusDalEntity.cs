namespace Wunderlist.DataAccess.Interfaces.Entities
{
    public class TaskStatusDalEntity : IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
