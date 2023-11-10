//�������������� ������������ ���� Microsoft.EntityFrameworkCore
//��� ������������� ���������������� Entity Framework Core
using UkraineSvoNews;
using Microsoft.EntityFrameworkCore;

//�������� ������� builder � ������� ������ WebApplication.CreateBuilder(args),
//��� args - ��������� ��������� ������ ��� ������� ����������
var builder = WebApplication.CreateBuilder(args);

// ���������� ����� � ��������� ������������ � ������� ������
// builder.Services.AddControllersWithViews(),
// ������� ��������� ������ ����������� ��� ������ � �������������
// � ��������������� MVC.
builder.Services.AddControllersWithViews();

//��������� ������ ����������� � �� �� ����� ������������
//����� ��� ������������: builder.Configuration["ConnectionStrings:Db"],
//��� ConnectionStrings:Db - ���� ��� ������ ������ �����������
var db = builder.Configuration.GetConnectionString("Db");

//���������� ��������� �� � ��������� ������������ � ������� ������
//builder.Services.AddDbContext<MainContext>() � ��������� �����������
//� �� � ������� options.UseSqlServer(db),
//��� MainContext - �����, �������������� �������� ��,
//� db - ������ ����������� � ��.
builder.Services.AddDbContext<MainContext>(options =>
{
    options.UseSqlServer(db);
});

//�������� ������� app � ������� ������ builder.Build(),
//������� ������� ��������� ���-����������
var app = builder.Build();

// ��������� ��������� ��������� HTTP-�������� � ������� �������,
// ��� ���������� �� ��������� � ������ ����������.
// � ���� ������ ����� �������������� ���������� ����������
// app.UseExceptionHandler("/Home/Error") � ����� ��������
// ������������� HSTS (HTTP Strict Transport Security)
// � ������� app.UseHsts() - ��������, ������������� ������������
// ���������� ���������� ����� �������� HTTPS.
// ������ �������� ������������ ��������� ����� �� �������������
// ���������� ���������� ������ ������������� HTTP-���������.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// ��������� ��������������� � HTTP �� HTTPS � ������� app.UseHttpsRedirection().
app.UseHttpsRedirection();

//���������� ������������ ����������� ������
//(��������, CSS, JavaScript, �����������)
//� ������� app.UseStaticFiles().
app.UseStaticFiles();

//��������� ������������� �������� � �������
app.UseRouting();

//��������� ������������� ��� ������������ � ������� ������
//app.MapControllerRoute(), ������� ����������,
//����� �������� ����� �������������� ��� ������������ MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
