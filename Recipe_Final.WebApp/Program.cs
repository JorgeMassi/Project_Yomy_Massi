using Recipes_Final.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
