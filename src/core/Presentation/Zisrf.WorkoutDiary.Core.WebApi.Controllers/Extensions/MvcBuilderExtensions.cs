using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.WebApi.Controllers.Tools;

namespace Zisrf.WorkoutDiary.Core.WebApi.Controllers.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder WithCoreControllers(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);

        return mvcBuilder;
    }
}