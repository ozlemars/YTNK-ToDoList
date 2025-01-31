using ToDoListMVC.Models;
namespace ToDoListMVC.ToDo.Service.Abstracts

{
    public interface IGorevService
    {
        Task<List<Gorev>> GetAllTasksAsync();
        Task<Gorev> GetTaskByIdAsync(Guid id);
        Task CreateTaskAsync(Gorev gorev);
        Task<Gorev> EditTaskAsync(Gorev gorev);
        Task<Gorev> DeleteTaskAsync(Guid id);
    }
}
