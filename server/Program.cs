using Docker.DotNet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Docker client
DockerClient dockerClient = new DockerClientConfiguration(
    new Uri("unix:///var/run/docker.sock")
).CreateClient();

try
{
    using var cts =
        new CancellationTokenSource(TimeSpan.FromSeconds(5));

    await dockerClient.System.PingAsync(cts.Token);
}
catch (Exception ex)
{
    throw new InvalidOperationException(
        "Unable to connect to Docker. Ensure Docker Engine is running " +
        "and that this application has permission to access /var/run/docker.sock.",
        ex
    );
}

builder.Services.AddSingleton(dockerClient);
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();