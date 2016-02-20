using System.Collections.Generic;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Avatar { get; set; }

        public virtual ICollection<ToDoList> ToDoLists { get; set; }

        public User()
        {
            ToDoLists = new List<ToDoList>();
        }
    }
}
