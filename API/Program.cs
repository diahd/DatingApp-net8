using API.Extensions;
//using API.Data;
//using API.Interfaces;
//using API.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dipindah ke extensions
//builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

////add cors
//builder.Services.AddCors();
//builder.Services.AddScoped<ITokenService, TokenService>();
//end dipindah ke extensions

builder.Services.AddApplicationServices(builder.Configuration);

//dipindah ke extension 2
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        //decrypt
//        var tokenKey = builder.Configuration["TokenKey"] ?? throw new Exception("TokenKey not found");
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });
//end dipindah ke extensions 2
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
//dikomen karena gapake swagger
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:4200", "https://localhost:4200"));

//urutan penting
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//end urutan penting

app.Run();
