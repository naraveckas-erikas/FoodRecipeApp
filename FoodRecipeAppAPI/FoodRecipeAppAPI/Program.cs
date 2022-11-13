using FoodRecipeAppAPI.Auth;
using FoodRecipeAppAPI.Auth.Models;
using FoodRecipeAppAPI.Data;
using FoodRecipeAppAPI.Data.Repositories;
using FoodRecipeAppAPI.Data.Repositories.Ingredients;
using FoodRecipeAppAPI.Data.Repositories.Recipes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecipeAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<RecipeAppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters.ValidAudience = builder.Configuration["JWT:ValidAudience"];
        options.TokenValidationParameters.ValidIssuer = builder.Configuration["JWT:ValidIssuer"];
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]));
    });

builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
builder.Services.AddTransient<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<AuthDbSeeder>();
builder.Services.AddSingleton<IAuthorizationHandler, ResourceOwnerAuthorizationHandler>();




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.ResourceOwner, policy => policy.Requirements.Add(new ResourceOwnerRequirement()));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers();

var dbSeeder = app.Services.CreateScope().ServiceProvider.GetRequiredService<AuthDbSeeder>();
await dbSeeder.SeedAsync();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
