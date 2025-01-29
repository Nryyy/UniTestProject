using HromadaWEB.Web;
using HromadaWEB.Web.Components;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// ������ �������� ���������� �� ��������� ������
builder.Services.AddControllers();
builder.AddServiceDefaults();

// ����������� Blazor Server �� Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

// **����������: ���������� BaseAddress**
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7358") });

// **(�� �������) �����������**
// builder.Services.AddScoped<AuthService>();
// builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
// builder.Services.AddAuthorizationCore();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// **(�����������) ��������, ���� HTTPS �� ���������������**
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // **�� �������!**
app.UseAntiforgery();
app.UseOutputCache();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
