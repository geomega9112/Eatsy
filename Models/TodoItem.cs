namespace eatsy_21._03._2024.Models;
//namespace TodoApi.Models
public class TodoItem
{
	public long Id { get; set; }
	public string? Name { get; set; }
	public bool IsComplete { get; set; }
	public string? Secret { get; set; }
}