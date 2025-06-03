namespace TodoMvc.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public int AssignedToId { get; set; }
        public User? AssignedTo { get; set; }
    }
}
