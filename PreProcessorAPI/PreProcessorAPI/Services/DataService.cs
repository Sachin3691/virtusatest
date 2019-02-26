using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PreProcessorAPI.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient httpClient = new HttpClient();
        ILoggerFactory _loggerFactory;
        ILogger Log;

        public DataService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            Log = _loggerFactory.CreateLogger("DataService");
        }

        public async Task GetData(List<string> phoneNumber)
        {
            var url = new Uri("http://localhost:3000/all");

            var res = await Policy
                  .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                      .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timespan, retryCount, context) =>
                      {
                      Log.LogInformation($"Failed to connect to DataService. Retry after {timespan} ");
                  })
                  .ExecuteAsync(() => httpClient.GetAsync(url));

            if (res.IsSuccessStatusCode)
            {
                Log.Log(LogLevel.Information, "Successfull");
            }
            else
            {
                Log.LogError($"Received invalid StatusCode, {res.StatusCode} ");
            }
        }
    }

    public interface IDataService
    {
        Task GetData(List<string> phoneNumber);
    }
}
