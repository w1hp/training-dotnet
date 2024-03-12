using Cvl.Training.SmsEmailSender.Core.Services;
using Cvl.Training.SmsEmailSender.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;


namespace Cvl.Training.SmsEmailSender.Core;

public static class SetupExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ISmsService, SmsService>();
        services.AddScoped<ISmsSenderService, SmsSenderService>();
        services.AddScoped<ISmsSynchronousService, SmsSynchronousService>();
        services.AddScoped<INipService, NipService>();


        return services;
    }
}
