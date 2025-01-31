using Microsoft.EntityFrameworkCore;
using ToDoListMVC.Models;
using ToDoListMVC.ToDo.Repository.Contexts;
using ToDoListMVC.ToDo.Service.Abstracts;

namespace ToDoListMVC.ToDo.Service.Concretes
{
    public class GorevService : IGorevService
    {
        private readonly BaseDbContext _context;
        public GorevService(BaseDbContext context)
        {
            _context = context;
        }
        public async Task CreateTaskAsync(Gorev gorev)
        {
            _context.Add(gorev);
            await _context.SaveChangesAsync();
           
        }

        public async Task<Gorev> DeleteTaskAsync(Guid id)
        {
            var gorev = await _context.Gorevler.FindAsync(id);
            if (gorev != null)
            {
                _context.Gorevler.Remove(gorev);
                await _context.SaveChangesAsync();
            }
            return gorev;
        }

        public async Task<Gorev> EditTaskAsync(Gorev gorev)
        {
           _context.Gorevler.Update(gorev);
            await _context.SaveChangesAsync();
            return gorev;

        }

        public async Task<List<Gorev>> GetAllTasksAsync()
        {
            return await _context.Gorevler.ToListAsync() ?? new List<Gorev>();
        }

        public async Task<Gorev> GetTaskByIdAsync(Guid id)
        {
            return await _context.Gorevler.FindAsync(id);
        }
    }
}
