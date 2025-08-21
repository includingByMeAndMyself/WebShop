using Api.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgresSqlDbContext(builder.Configuration);
builder.Services.AddPostgresSqlIdentityContext();
builder.Services.AddConfigureIdentityOption();
builder.Services.AddJwtTokenGenerator();
builder.Services.AddAuthenticationService(builder.Configuration);
builder.Services.AddCors();


var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o =>
{
    o.AllowAnyHeader();
    o.AllowAnyMethod();
    o.AllowAnyOrigin();
    o.WithExposedHeaders("*");
});

app.UseAuthentication();
app.UseAuthorization();

await app.Services.InitializeRoleAsync();
app.Run();
