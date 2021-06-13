using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;

namespace MovieShop.MVC.Middlewares
{
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // do your exception handling
                _logger.LogInformation("Some Exception happened, caught in this middleware: ");

                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            // get the exception, log with serilog and send email to dev team

            _logger.LogError(" Starting Exception Logging: ");

            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var errorResponse = new
            {
                ExceptionMessage = ex.Message,
                InnerExceptionMessage = ex.InnerException,
                ExceptionStackStrace = ex.StackTrace
            };

            // Log above object with Serilog
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File("Log/ExceptionLog.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                    .CreateLogger();

            Log.Information($"Exception Message: {errorResponse.ExceptionMessage}, InnerException Message: {errorResponse.InnerExceptionMessage}, Exception happened on {DateTime.Now}, StackTrace Of Exception {errorResponse.ExceptionStackStrace}");
            Log.CloseAndFlush();

            //// send email to the Dev Team
            //var EmailId = ""; // Type Email Id here
            //var Password = ""; // Type Password here
            //string to = "stephenmei1997@gmail.com"; //To address
            //string from = "stephenmei1997@gmail.com"; //From address
            //MailMessage message = new MailMessage(from, to);

            //string mailbody = "Testing: Exception Messasge\n" +
            //    "Exception Message: {errorResponse.ExceptionMessage},\n" +
            //    "InnerException Message: {errorResponse.InnerExceptionMessage},\n" +
            //    "Exception happened on {DateTime.Now},\nStackTrace Of Exception {errorResponse.ExceptionStackStrace}";
            //message.Subject = "[Testing] Send exception messages to Dev team";
            //message.Body = mailbody;
            //message.BodyEncoding = Encoding.UTF8;
            //message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential(EmailId, Password);
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;
            //try
            //{
            //    client.Send(message);
            //}
            //catch (Exception em)
            //{
            //    throw new Exception("Email Authorization failed.");
            //}

            _logger.LogError("Exception Message: {0}", errorResponse.ExceptionMessage);
            _logger.LogError("Exception happened on {0}", DateTime.Now);
            _logger.LogError("StackTrace Of Exception {0}", errorResponse.ExceptionStackStrace);

            // redirect to a error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
