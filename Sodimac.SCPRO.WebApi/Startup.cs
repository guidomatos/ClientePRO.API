using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sodimac.SCPRO.Common.Resource;
using Sodimac.SCPRO.DomainModel;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.DomainModel.Repository.ClientePRO;
using Sodimac.SCPRO.DomainModel.Repository.Master;
using Sodimac.SCPRO.DomainService.Core;
using Sodimac.SCPRO.DomainService.Interface.ClientePRO;
using Sodimac.SCPRO.DomainService.Interface.Master;
using Sodimac.SCPRO.DomainService.Service.ClientePRO;
using Sodimac.SCPRO.DomainService.Service.Master;
using System;

namespace Sodimac.SCPRO.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            // configure context db
            services.AddDbContextPool<ScproContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Connection.Scpro),
                                                                                    opt => opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddAutoMapper(typeof(Startup));

            // Services
            services.AddScoped<ITypeIdentityDocumentService, TypeIdentityDocumentService>();
            services.AddScoped<ISexService, SexService>();
            services.AddScoped<IEducationalLevelService, EducationalLevelService>();
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<IUbigeoService, UbigeoService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IReasonDisinscriptionService, ReasonDisinscriptionService>();
            services.AddScoped<IDisinscriptionService, DisinscriptionService>();

            // Repositories
            services.AddScoped<ITypeIdentityDocumentRepository, TypeIdentityDocumentRepository>();
            services.AddScoped<ISexRepository, SexRepository>();
            services.AddScoped<IEducationalLevelRepository, EducationalLevelRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<IUbigeoRepository, UbigeoRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IReasonDisinscriptionRepository, ReasonDisinscriptionRepository>();
            services.AddScoped<IDisinscriptionRepository, DisinscriptionRepository>();
            services.AddScoped<IDisinscriptionEvidenceRepository, DisinscriptionEvidenceRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
