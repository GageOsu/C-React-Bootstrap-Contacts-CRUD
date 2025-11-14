var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var stringConnection = builder.Configuration.GetConnectionString("SqliteStringConnection");
builder.Services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));

builder.Services.AddCors(opt =>
opt.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(builder.Configuration["client"]);
}));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
