using Application.Dto.ResponseObject;
using Application.Helper.CustomException;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Business
{
    public class ExceptionMiddleware
    {
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex) when (ex is FilterPropertyException || ex is ImageUploadFailedException 
			|| ex is OwnerNotFoundException || ex is PropertyNotFoundException)
			{
				await HandleExceptionAsync(httpContext, ex,StatusResponse.UserError, (int)HttpStatusCode.BadRequest);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex, StatusResponse.SystemError, (int)HttpStatusCode.InternalServerError);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context,Exception exception, StatusResponse statusResponse, int statusCode)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = statusCode;

			await context.Response.WriteAsync(new Response()
			{
				status = statusResponse,
				message = exception.Message
			}.ToString());
		}
	}
}
