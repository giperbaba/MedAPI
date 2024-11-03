using medicalInformationSystem.Middleware;

namespace medicalInformationSystem.Configurations;

public static class MiddlewareConfiguration
{
    public static void ConfigureMiddleware(IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}