using Gamestorev3.Server.Controllers;
using System.Net;
using System.Text.Json;

namespace Gamestorev3.Server.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate del;
        private readonly ILogger<ExceptionMiddleware> log;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate del, ILogger<ExceptionMiddleware> log, IHostEnvironment env)
        {
            this.del = del;
            this.log = log;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext con) 
        {
            try { await del(con); }
            catch(Exception ex)
            {
                log.LogError(ex, ex.Message);
                con.Response.ContentType = "application/json";
                con.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment()
                    ? new ExceptionAPI(con.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ExceptionAPI(con.Response.StatusCode, ex.Message, "Internal Server Error");

                var serial = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, serial);

                await con.Response.WriteAsync(json);

            }

        }
    }
}
