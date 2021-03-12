using DoIt.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoIt.Client.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
    }
}