namespace BackEnd.Api.Abstractions
{
    public interface IModule
    {
        WebApplicationBuilder RegisterModule(WebApplicationBuilder builder);
        IEndpointRouteBuilder MapEnpoints(IEndpointRouteBuilder endpoints);

    }
}