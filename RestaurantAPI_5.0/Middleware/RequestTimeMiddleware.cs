﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestaurantAPI_5._0.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly Stopwatch _stopWatch;
        private readonly ILogger _logger;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();
            
            var elapsedMiliseconds = _stopWatch.ElapsedMilliseconds;
            if(elapsedMiliseconds/1000> 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMiliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
