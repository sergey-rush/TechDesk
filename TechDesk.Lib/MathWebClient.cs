using RestSharp;
using System;
using TechDesk.Common;
using TechDesk.IService;
using TechDesk.Model.ViewModel;

namespace TechDesk.Lib
{
    public class MathWebClient:IDependency
    {
        private readonly ILogService logService;
        private IRestClient _restClient;

        public MathWebClient(ILogService logService)
        {
            _restClient = new RestClient("http://localhost/api/math");
            this.logService = logService;
        }

        public int Add(int a, int b)
        {
            string result = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET)).Content;
            logService.AddLog(new Log(LogLevel.Info, $"Method Add({a}, {b}) returned {result}", nameof(MathWebClient)));
            return Convert.ToInt32(result);
        }

        public int Multiply(int a, int b)
        {
            string result = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET)).Content;
            logService.AddLog(new Log(LogLevel.Info, $"Method Multiply({a}, {b}) returned {result}", nameof(MathWebClient)));
            return Convert.ToInt32(result);
        }

        public int Divide(int a, int b)
        {
            string result = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET)).Content;
            if (string.IsNullOrEmpty(result)){result = "0";}
            logService.AddLog(new Log(LogLevel.Info, $"Method Divide({a}, {b}) returned {result}", nameof(MathWebClient)));
            return Convert.ToInt32(result);
        }
    }
}
