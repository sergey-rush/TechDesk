using System.Collections.Generic;
using System.Threading.Tasks;
using TechDesk.Data;
using TechDesk.IRepository;
using TechDesk.TableModel;

namespace TechDesk.Repository
{
    public class LogRepository : ILogRepository
    {
        public IDbContext dbContext;
        public LogRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddLog(LogTableModel log)
        {
            string query = "insert into logs(LogLevel, Info, DataType, Created) values (@LogLevel, @Info, @DataType, @Created);";
            int row = await dbContext.Update<LogTableModel>(query, log);
            return row > 0 ? true : false;
        }

        public async Task<IEnumerable<LogTableModel>> GetList(int limit)
        {
            var query = "SELECT Id, LogLevel, Info, DataType, Created FROM logs ORDER BY Id DESC LIMIT @Limit;";
            var list = await dbContext.Select<LogTableModel>(query, new {Limit = limit});
            return list;
        }

        public async Task<LogTableModel> GetLogById(int id)
        {
            var query = string.Format("SELECT Id, LogLevel, Info, DataType, Created FROM logs WHERE Id=@Id");
            var log = await dbContext.SelectFirst<LogTableModel>(query, new { Id = id });
            return log;
        }

        public async Task<IEnumerable<LogTableModel>> GetLogList(int pageIndex, int pageSize)
        {
            var sql = string.Format("SELECT Id, LogLevel, Info, DataType, Created FROM logs LIMIT @Start, @End");
            var list = await dbContext.Select<LogTableModel>(sql, new { Start = (pageIndex - 1) * pageSize, End = pageSize });
            return list;
        }

        public async Task<bool> UpdateLog(LogTableModel log)
        {
            var sql = string.Format("UPDATE logs SET LogLevel=@LogLevel, Info=@Info, DataType=@DataType where Id=@Id");
            var row = await dbContext.Update<LogTableModel>(sql, log);
            return row > 0 ? true : false;
        }
    }
}