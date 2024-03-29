﻿using System.Text;
using Framework.Api.Jwt;
using Framework.Application.Sms;
using IranCafe.Infrastructure.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Framework.Application.Hashing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Framework.Application.Authentication;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc.Filters;
using IranCafe.Infrastructure.EfCore;
using IranCafe.Domain.AccountAgg;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.

service.AddHttpContextAccessor();
service.AddTransient<IJwtHelper, JwtHelper>();
service.AddTransient<IAuthHelper, AuthHelper>();
service.AddTransient<ISmsService, SmsService>();
service.AddTransient<IPasswordHasher, PasswordHasher>();
CafeBootstrapper.Configure(service, builder.Configuration.GetConnectionString("Ir-Cafe"));

service.AddControllersWithViews();

#region html encoder

service.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));

#endregion

service.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie(o =>
{
    o.LoginPath = "/Account/Login";
    o.LogoutPath = "/Account/Logout";
    o.AccessDeniedPath = new PathString("/NotFound");
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Seed Operator
void SeedDatabase() 
{
    using (var scope = app.Services.CreateScope())
    {
        var _context = scope.ServiceProvider.GetRequiredService<CafeContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        Operator opt = _context.Operators.Where(i => i.Mobile == "09151498722").FirstOrDefault()!;
        if (opt is null)
        {
            string hashpassword = passwordHasher.Hash("123");
            //password: 123
            Operator admin = new Operator("حمید بلال زاده", "09151498722", hashpassword);

            _context.Operators.Add(admin);
            _context.SaveChanges();
        }
    }
}

SeedDatabase();

app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}"
        );

app.Run();