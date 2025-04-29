using Microsoft.AspNetCore.Identity.Data;

namespace StoreDemo.Application.Response;
public class BaseResponse<TResponse> where TResponse : class
{
    public TResponse? Result { get; set; } = default!;
    public List<string> Errors { get; set; } = new List<string>();
}


public class BaseResponse
{
    public List<string> Errors { get; set; } = new List<string>();
}