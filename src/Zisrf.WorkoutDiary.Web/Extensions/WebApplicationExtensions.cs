using Zisrf.WorkoutDiary.Core.DataAccess.Extensions;

namespace Zisrf.WorkoutDiary.Web.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication Configure(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        // application.UseExceptionHandling();

        application.UseHttpsRedirection();

        application.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

        application.UseAuthorization();

        application.MapControllers();

        return application;
    }

    public static async Task InitializeAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();

        await scope.InitializeDbAsync();
    }
}