using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechDesk.IRepository;
using TechDesk.IService;
using TechDesk.Model.ViewModel;
using TechDesk.Common;
using TechDesk.TableModel;

namespace TechDesk.Service
{
    public class LogService: ILogService
    {
        public ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public Task<bool> AddLog(Log log)
        {
            LogTableModel model = new LogTableModel()
            {
                LogLevel = (int)log.LogLevel,
                Info = log.Info,
                DataType = log.DataType,
                Created = log.Created
            };

            return logRepository.AddLog(model);
        }

        public async Task<Log> GetLogById(int id)
        {
            var l = await logRepository.GetLogById(id);
            Log log = new Log()
                    {
                        Id = l.Id,
                        LogLevel = (LogLevel)l.LogLevel,
                        Info = l.Info,
                        DataType = l.DataType,
                        Created = l.Created
                    };
            return log;
        }

        public IEnumerable<Log> GetList(int limit)
        {
            var list = logRepository.GetList(limit);
            var logList = new List<Log>();
            list.Result.ToList().ForEach(l =>
            {
                logList.Add(
                    new Log
                    {
                        Id = l.Id,
                        LogLevel = (LogLevel)l.LogLevel,
                        Info = l.Info,
                        DataType = l.DataType,
                        Created = l.Created
                    });
            });
            return logList;
        }
    }
}