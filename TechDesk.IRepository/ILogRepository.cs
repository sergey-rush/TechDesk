using System.Collections.Generic;
using System.Threading.Tasks;
using TechDesk.Common;
using TechDesk.TableModel;

namespace TechDesk.IRepository
{
    public interface ILogRepository: IDependency
    {
        Task<IEnumerable<LogTableModel>> GetList(int limit);
        
        Task<bool> AddLog(LogTableModel log);
        
        Task<bool> UpdateLog(LogTableModel log);

        Task<LogTableModel> GetLogById(int id);

        Task<IEnumerable<LogTableModel>> GetLogList(int PageIndex, int PageSize);
    }
}