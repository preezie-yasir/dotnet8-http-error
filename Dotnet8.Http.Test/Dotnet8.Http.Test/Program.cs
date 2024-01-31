using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async Task<Results<Ok<OkResult>, BadRequest<BadRequestResult>>> () =>
{
    var httpClient = new HttpClient();
    httpClient.Timeout = TimeSpan.FromMinutes(40);
    
    try
    {
        var response = await httpClient.GetAsync(
            "https://webadapters.channeladvisor.com/CSEAdapter/Default.aspx?pid=WZP%5e%5eF%5eSAnHKt5*-U%5beC2TQjvwI_%26%2b%22%60%5bJ_Q)nHHHc%26%5c%24KaL3QV%3duI%3d6(*%23%5bbIdQQnGy%40_WaUecw%5dRTlHJ");

        return TypedResults.Ok(new OkResult
        {
            StatusCode = response.StatusCode,
            ReasonPhrase = response.ReasonPhrase,
            IsSuccessStatusCode = response.IsSuccessStatusCode
        });
    }
    catch (Exception e)
    {
        return TypedResults.BadRequest(new BadRequestResult
        {
            Message = e.Message,
            InnerExceptionMessage = e.InnerException.Message,
            InnerInnerExceptionMessage = e.InnerException.InnerException.Message,
            InnerInnerInnerExceptionMessage = e.InnerException.InnerException.InnerException.Message,
            StackTrace = e.StackTrace,
            InnerStackTrace = e.InnerException.StackTrace,
            InnerInnerStackTrace = e.InnerException.InnerException.StackTrace,
            InnerInnerInnerStackTrace = e.InnerException.InnerException.InnerException.StackTrace
        });
    }
});

app.Run();

public class OkResult
{
    public HttpStatusCode StatusCode { get; set; }
    public string ReasonPhrase { get; set; }
    public bool IsSuccessStatusCode { get; set; }
    public string Response { get; set; }
}

public class BadRequestResult
{
    public string Message { get; set; }
    public string InnerExceptionMessage { get; set; }
    public string InnerInnerExceptionMessage { get; set; }
    public string InnerInnerInnerExceptionMessage { get; set; }
    public string StackTrace { get; set; }
    public string InnerStackTrace { get; set; }
    public string InnerInnerStackTrace { get; set; }
    public string InnerInnerInnerStackTrace { get; set; }
}