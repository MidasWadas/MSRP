using MSRP.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		policy =>
		{
			policy.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
