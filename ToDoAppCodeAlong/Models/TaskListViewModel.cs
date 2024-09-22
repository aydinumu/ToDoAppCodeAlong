namespace ToDoAppCodeAlong.Models
{
	public class TaskListViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public bool IsDone { get; set; }
		public string OwnerName { get; set; }
	}
}