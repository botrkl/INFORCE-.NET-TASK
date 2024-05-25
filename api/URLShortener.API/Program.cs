using URLShortener.DAL.Extensions;
using URLShortener.BLL.Extensions;
using URLShortener.API.WebMapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(UserDtoMapperProfile));
builder.Services.InjectDAL(builder.Configuration);
builder.Services.InjectBLL();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
