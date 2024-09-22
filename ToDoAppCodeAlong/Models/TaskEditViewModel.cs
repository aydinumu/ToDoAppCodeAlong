namespace ToDoAppCodeAlong.Models
{
	public class TaskEditViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int OwnerId { get; set; }
	}
}