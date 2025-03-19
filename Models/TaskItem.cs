namespace ToDoList.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime? TaskDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsBeingEdited { get; set; }
    }
}
