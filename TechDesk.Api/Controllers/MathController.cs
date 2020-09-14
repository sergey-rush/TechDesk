using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechDesk.Common;
using TechDesk.IService;
using TechDesk.Model.ViewModel;

namespace TechDesk.Api.Controllers
{
    public class MathController : ApiController
    {
        private readonly ILogService logService;

        public MathController(ILogService logService)
        {
            this.logService = logService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            logService.AddLog(new Log(LogLevel.Trace, "Method Get() called", nameof(MathController)));
            var list = logService.GetList(10);
            return Request.CreateResponse(list);
        }

        [HttpGet]
        public HttpResponseMessage Add(int a, int b)
        {
            int result = a + b;
            logService.AddLog(new Log(LogLevel.Info, $"Method Add({a}, {b}) returned {result}", nameof(MathController)));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        public HttpResponseMessage Multiply(int a, int b)
        {
            int result = a * b;
            logService.AddLog(new Log(LogLevel.Info, $"Method Multiply({a}, {b}) returned {result}", nameof(MathController)));
            return Request.CreateResponse(result);
        }

        [HttpGet]
        public HttpResponseMessage Divide(int a, int b)
        {
            try
            {
                int result = a / b;
                logService.AddLog(new Log(LogLevel.Info, $"Method Divide({a}, {b}) returned {result}", nameof(MathController)));
                return Request.CreateResponse(result);
            }
            catch (Exception ex)
            {
                logService.AddLog(new Log(LogLevel.Error, ex.Message, nameof(MathController)));
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
