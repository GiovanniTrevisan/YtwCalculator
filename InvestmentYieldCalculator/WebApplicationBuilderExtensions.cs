using IMTC.CodeTest.Core.Services;
using IMTC.CodeTest.Calculators;
using IMTC.CodeTest.Indices.Services;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IImtcCalculator, ImtcCalculator>();
        builder.Services.AddScoped<IYtwCalculator, YtwCalculator>();
        builder.Services.AddScoped<ITimeService, TimeService>();
        builder.Services.AddScoped<IIndexProvider, IndexProvider>();
        return builder;
    }
}
