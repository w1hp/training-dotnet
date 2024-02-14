using Cvl.Training.SmsEmailSender.Core.Base;
using Cvl.Training.SmsEmailSender.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cvl.Training.SmsEmailSender.Infrastructure
{
    public static class SetupExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            string? infrastructureDbContextConnectionString)
        {
            if (infrastructureDbContextConnectionString == null) throw new ArgumentNullException(nameof(infrastructureDbContextConnectionString));


            //db context - aplikacji
            services.AddDbContext<SmsEmailDbContext>(options =>
                options.UseNpgsql(infrastructureDbContextConnectionString,
                options =>
                {
                    options.SetPostgresVersion(new Version(9, 6));
                    options.CommandTimeout(60 * 5);
                }));

            services.AddTransient((provider) => new Func<ITransientWriterEntities>(() => new SmsEmailDbContext(infrastructureDbContextConnectionString)));
            services.AddScoped<IWriteEntities, SmsEmailDbContext>(di => di.GetRequiredService<SmsEmailDbContext>());
            //services.AddScoped<IToDataGridService, ToDataGridService>();
            //services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IEmailHelperService, EmailHelperService>();
            //services.AddScoped<ISmsService, SmsService>();
            //services.AddScoped<IChiquitaService, ChiquitaService>();
            //services.AddScoped<IFileRepositoryService, FileRepositoryService>();
            //services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
            //services.AddScoped<IGenerateFactoringRequestPdfService,GenerateFactoringRequestPdfService>();
            //services.AddScoped<IGeneratePersonRequestPdfService, GeneratePersonRequestPdfService>();

            return services;
        }
    }
}
