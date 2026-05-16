using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// 1. Rejestracja pierwszego kontekstu bazy danych
builder.Services.AddDbContext<SklepSDKW_EF.DAL.SklepContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("localDB")));

// 2. TUTAJ DOPISUJEMY REJESTRACJÊ DRUGIEGO KONTEKSTU (DLA MENU)
builder.Services.AddDbContext<SklepSDKW_EF.DAL.FilmsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("localDB")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// --- POPRAWIONA KONFIGURACJA SESJI W US£UGACH CONTENERA ---
builder.Services.AddDistributedMemoryCache(); // Rejestracja pamiêci podrêcznej dla sesji
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Czas wygaœniêcia sesji koszyka (30 minut)
    options.Cookie.HttpOnly = true;                 // Poprawiona œcie¿ka dostêpu do w³aœciwoœci HttpOnly
    options.Cookie.IsEssential = true;              // Poprawiona œcie¿ka dostêpu do w³aœciwoœci IsEssential
});

// Konfiguracja polskiej kultury jêzykowej dla formularzy i walidacji
var supportedCultures = new[] { new CultureInfo("pl-PL") };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("pl-PL");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// W³¹czenie obs³ugi polskiej lokalizacji w potoku ¿¹dañ HTTP
app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

// --- W£¥CZENIE SESJI W POTOKU ¯¥DAÑ HTTP ---
app.UseSession(); // Musi byæ wywo³ane po UseRouting() i przed MapControllerRoute()

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// --- AUTOMATYCZNA AKTUALIZACJA BAZY DANYCH PRZED STARTEM ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var sklepContext = services.GetRequiredService<SklepSDKW_EF.DAL.SklepContext>();
        sklepContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Logowanie b³êdu w razie potrzeby
    }
}

app.Run();