using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//
// ADD CONTROLLERS
//
builder.Services.AddControllers();

//
// SWAGGER
//
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//
// JWT AUTHENTICATION
//
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;

    options.SaveToken = true;

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,

            ValidateAudience = true,

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,

            ValidIssuer =
                builder.Configuration["Jwt:Issuer"],

            ValidAudience =
                builder.Configuration["Jwt:Audience"],

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        builder.Configuration["Jwt:Key"]))
        };
});

//
// AUTHORIZATION
//
builder.Services.AddAuthorization();

var app = builder.Build();

//
// SWAGGER
//
app.UseSwagger();

app.UseSwaggerUI();

//
// HTTPS
//
app.UseHttpsRedirection();

//
// AUTHENTICATION
//
app.UseAuthentication();

//
// AUTHORIZATION
//
app.UseAuthorization();

//
// MAP CONTROLLERS
//
app.MapControllers();

app.Run();