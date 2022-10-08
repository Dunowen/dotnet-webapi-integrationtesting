using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleWebApp.Api.Extensions;
using SimpleWebApp.DTOs.Validators;
using SimpleWebApp.Persistence;

namespace SimpleWebApp.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddAutoMapper(typeof(Program));

			builder.Services.AddDbContext<DatabaseContext>(c =>
				c.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
			builder.Services.CreateDatabase();

			builder.Services.AddFluentValidationAutoValidation();
			builder.Services.AddValidatorsFromAssemblyContaining<UserRequestDtoValidator>();

			builder.Services.ConfigureDependencyInjection();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}