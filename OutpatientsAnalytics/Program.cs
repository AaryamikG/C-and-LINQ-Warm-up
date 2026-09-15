using OutpatientsAnalytics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register services for dependency injection
builder.Services.AddSingleton<IDataContext, InMemoryDataContext>(); // Singleton: immutable data, expensive to create
builder.Services.AddScoped<ReportsService>(); // Scoped: per-request service that processes data

var app = builder.Build();

// Print the three business reports to the console for a quick sanity check.
using (var scope = app.Services.CreateScope())
{
    var reportsService = scope.ServiceProvider.GetRequiredService<ReportsService>();

    Console.WriteLine("=== No-Show Rates by Department ===");
    foreach (var report in reportsService.GetNoShowRatesByDepartment())
    {
        Console.WriteLine($"{report.DepartmentName}: {report.NoShowRate:P1} ({report.NoShowCount}/{report.TotalAppointments})");
    }

    Console.WriteLine();
    Console.WriteLine("=== Top 3 Clinicians This Month ===");
    foreach (var report in reportsService.GetTopCliniciansThisMonth())
    {
        Console.WriteLine($"{report.ClinicianName} ({report.Specialty}): {report.CompletedAppointments} completed");
    }

    Console.WriteLine();
    Console.WriteLine("=== Average Wait Time (days) by Specialty ===");
    foreach (var report in reportsService.GetAverageWaitTimesBySpecialty())
    {
        Console.WriteLine($"{report.Specialty}: {report.AverageWaitTimeDays:F1} days");
    }

    Console.WriteLine();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
