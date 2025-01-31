using System.ComponentModel.DataAnnotations;

namespace ToDoListMVC.Models;

public class Gorev
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Görev adý boþ býrakýlamaz.")]
    public string TaskName { get; set; }
    public string Description {  get; set; }
    public bool IsCompleted { get; set; }
    [Required(ErrorMessage = "Son tarih boþ býrakýlamaz.")]
    public DateTime? Deadline { get; set; }
    public string? AssignedBy { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
}