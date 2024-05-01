using Recipes_Final.IService.Implementation;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Implementation;
using Recipes_Final.Repository.Interface;
using Recipes_Final.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.//
builder.Services.AddScoped<IRepository<Difficulty, int>, DifficultyRepository>();
builder.Services.AddScoped<IRepository<Measures, int>, MeasuresRepository>();
builder.Services.AddScoped<IRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Ingredient, int>, IngredientRepository>();
builder.Services.AddScoped<IRepository<User, int>, UserRepository>();
builder.Services.AddScoped<IRepository<Recipes, int>, RecipesRepository>();

builder.Services.AddScoped<IService<Difficulty, int>, DifficultyService>();
builder.Services.AddScoped<IService<Measures, int>, MeasuresService>();
builder.Services.AddScoped<IService<Category, int>, CategoryService>();
builder.Services.AddScoped<IService<Ingredient, int>, IngredientService>();
builder.Services.AddScoped<IService<User, int>, UserService>();
builder.Services.AddScoped<IService<Recipes, int>, RecipesService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
