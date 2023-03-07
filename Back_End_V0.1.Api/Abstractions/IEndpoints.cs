namespace BackEnd.Api.Api.Abstractions
{
    public interface IEndpoints
    {
        IEndpointRouteBuilder RegisterRoutes (IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}
