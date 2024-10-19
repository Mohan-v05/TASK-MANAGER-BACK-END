
using Activity26.Data;
using Microsoft.EntityFrameworkCore;

namespace Activity26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDBcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBconnection")));
            //builder.Services.AddCors(option =>
            //{
            //    option.AddPolicy(
            //        name: "CorsPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod;
            //        });
            //});
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        builder =>
            //        {
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials();
            //        });
            //});
            const string policyName = "CorsPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policyName);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
