using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.Extention;
using Optivem.Framework.Core.Domain;




namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<RequestMedicinesContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(RequestMedicinesContext).Assembly.FullName)));
            // Add services to the container.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<RequestMedicinesContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCustom(builder.Configuration);

            var app = builder.Build();

         

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};
            app.UseCors(e => e.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();   
          
            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseAuthentication();
            app.MapControllers();


            app.Run();
        }
    }
}