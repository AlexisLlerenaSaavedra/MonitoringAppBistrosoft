using MonitoringApp.WebApi.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


// Registrar servicios de la Web API
builder.Services.AddWebApiServices(); 




builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "MonitoringApp API",
		Version = "v1",
		Description = "API para gestionar el estado de plataformas"
	});
});

// Configura los servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();



// Configurar middleware
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();
// Habilita CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();

