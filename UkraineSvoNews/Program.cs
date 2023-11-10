//Импортирование пространства имен Microsoft.EntityFrameworkCore
//для использования функциональности Entity Framework Core
using UkraineSvoNews;
using Microsoft.EntityFrameworkCore;

//Создание объекта builder с помощью метода WebApplication.CreateBuilder(args),
//где args - аргументы командной строки при запуске приложения
var builder = WebApplication.CreateBuilder(args);

// Добавление служб в контейнер зависимостей с помощью метода
// builder.Services.AddControllersWithViews(),
// который добавляет службы необходимые для работы с контроллерами
// и представлениями MVC.
builder.Services.AddControllersWithViews();

//Получение строки подключения к БД из файла конфигурации
//Можно еще использовать: builder.Configuration["ConnectionStrings:Db"],
//где ConnectionStrings:Db - ключ для поиска строки подключения
var db = builder.Configuration.GetConnectionString("Db");

//Добавление контекста БД в контейнер зависимостей с помощью метода
//builder.Services.AddDbContext<MainContext>() и настройке подключения
//к БД с помощью options.UseSqlServer(db),
//где MainContext - класс, представляющий контекст БД,
//а db - строка подключения к БД.
builder.Services.AddDbContext<MainContext>(options =>
{
    options.UseSqlServer(db);
});

//Создание объекта app с помощью метода builder.Build(),
//который создает экземпляр веб-приложения
var app = builder.Build();

// Настройка конвейера обработки HTTP-запросов с помощью условия,
// что приложение не находится в режиме разработки.
// В этом случае будет использоваться обработчик исключений
// app.UseExceptionHandler("/Home/Error") и будет включено
// использование HSTS (HTTP Strict Transport Security)
// с помощью app.UseHsts() - механизм, принудительно активирующий
// защищённое соединение через протокол HTTPS.
// Данная политика безопасности позволяет сразу же устанавливать
// безопасное соединение вместо использования HTTP-протокола.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Включение перенаправления с HTTP на HTTPS с помощью app.UseHttpsRedirection().
app.UseHttpsRedirection();

//Разрешение обслуживания статических файлов
//(например, CSS, JavaScript, изображения)
//с помощью app.UseStaticFiles().
app.UseStaticFiles();

//Настройка маршрутизации запросов с помощью
app.UseRouting();

//Настройка маршрутизации для контроллеров с помощью метода
//app.MapControllerRoute(), который определяет,
//какие маршруты будут использоваться для контроллеров MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
