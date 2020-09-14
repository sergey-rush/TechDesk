using System.Collections.Generic;
using System.Threading.Tasks;
using TechDesk.Common;
using TechDesk.Model.ViewModel;

namespace TechDesk.IService
{
    public interface ILogService: IDependency
    {
        IEnumerable<Log> GetList(int limit);
        Task<bool> AddLog(Log log);
        Task<Log> GetLogById(int id);
    }
}