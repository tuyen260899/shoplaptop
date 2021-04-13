using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShopLaptopInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptop.Api
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopLaptop.Api", Version = "v1" });
            });
            services.AddScoped<ILoaiSPRepository, LoaiSPRepository>();
            services.AddScoped<ILoaiSPService, LoaiSPService>();
            services.AddScoped<ISanPhamRepository, SanPhamRepository>();
            services.AddScoped<ISanPhamService, SanPhamService>();
            services.AddScoped<IKhachHangRepository, KhachHangRepository>();
            services.AddScoped<IKhachHangService, KhachHangService>();
            services.AddScoped<IKhoRepository, KhoRepository>();
            services.AddScoped<IKhoService, KhoService>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();
            services.AddScoped<IHoaDonService, HoaDonService>();
            services.AddScoped<IPhieuNhapRepository, PhieuNhapRepository>();
            services.AddScoped<IPhieuNhapService, PhieuNhapService>();
            services.AddScoped<IChiTietHDRepository, ChiTietHDRepository>();
            services.AddScoped<IChiTietHDService, ChiTietHDService>();
            services.AddScoped<IChiTietPNRepository, ChiTietPNRepository>();
            services.AddScoped<IChiTietPNService, ChiTietPNService>();
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService>();
            services.AddScoped<INhaSXRepository, NhaSXRepository>();
            services.AddScoped<INhaSXService, NhaSXService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopLaptop.Api v1"));
            }

            app.UseRouting();
            app.UseCors(option => option.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
