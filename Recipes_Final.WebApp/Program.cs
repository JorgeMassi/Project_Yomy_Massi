//
using Recipes_Final.IService.Implementation;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Implementation;
using Recipes_Final.Repository.Interface;
using Recipes_Final.Service.Implementation;
using Recipes_Final.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository<Difficulty, int>, DifficultyRepository>();
builder.Services.AddScoped<IRepository<Measure, int>, MeasuresRepository>();
builder.Services.AddScoped<IRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Ingredient, int>, IngredientRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IIngLineRepository, IngredientLineRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

builder.Services.AddScoped<IRepository<Recipe, int>, RecipesRepository>();
builder.Services.AddScoped<IRepository<Favorite, int>, FavoriteRepository>();
builder.Services.AddScoped<IRepository<Post, int>, PostRepository>();


builder.Services.AddScoped<IService<Difficulty, int>, DifficultyService>();
builder.Services.AddScoped<IService<Category, int>, CategoryService>();
builder.Services.AddScoped<IService<Measure, int>, MeasuresService>();
builder.Services.AddScoped<IService<Ingredient, int>, IngredientService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIngLineService, IngredientLineService>();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddScoped<IService<Recipe, int>, RecipesService>();
builder.Services.AddScoped<IService<Favorite, int>, FavoriteService>();
builder.Services.AddScoped<IService<Post, int>, PostService>();



builder.Services.AddSession(options =>
{
    options.Cookie.Name = "ChipsAhoy";
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.IsEssential = true;
});


builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.MapRazorPages();

app.Run();
