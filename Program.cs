using System.Net;
using System.Text.RegularExpressions;
using Controller_View.Areas.Product.Services;
using Controller_View.ExtendMethods;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// services.AddSingleton<ProductService>();
// services.AddSingleton<ProductService, ProductService>();
// services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductServices), typeof(ProductServices));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // Views/Controller/Action.cshtml
    // MyViews/Controller/Action.cshtml
    // {0} -> Action
    // {1} -> Controller
    // {2} -> Areas
    options.ViewLocationFormats.Add("/MyAreas/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddRazorPages();

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

app.UseRouting();

app.AddStatusCodePage();

app.UseAuthentication();
app.UseAuthorization();
// app.MapRazorPages();


app.MapControllerRoute(
       name: "myroute",
       defaults: new { controller = "First", action = "Index" },
       pattern: "/test");



/*
 * Ở Route tên myroute phù hợp khi truy cập URL dạng /tieude-134.html,
 * ROUTE này không chỉ rõ Controller, Action trong pattern mà 
 * chỉ ra trong defaults như trên. 
 * Các Url phù hợp đều dẫn đến thi hành HomeController::Index
*/
app.MapControllerRoute(
       name: "myroute",
       defaults: new { controller = "Home", action = "Index" },
       pattern: "{title}-{id}.html");

// ràng buộc route với ReGex
app.MapControllerRoute(
       name: "myroute",                                                     // đặt tên route
       defaults: new { controller = "Home", action = "Index" },
       constraints: new
       {
           id = @"\d+",                                                 // id phải có và phải là số
           title = new RegexRouteConstraint(new Regex(@"^[a-z0-9-]*$"))    // title chỉ chứa số, chữ thường và ký hiệu -
       },
       pattern: "{title}-{id}.html");

// ràng buộc trực tiép
app.MapControllerRoute(
   name: "myroute", // đặt tên route
   defaults: new { controller = "Home", action = "Index" },
   pattern: "{title:alpha:maxlength(8)}-{id:int}.html");
// title chỉ chứa các chữ cái, dài tối đa 8, id là số nguyên


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// là pattern default, đặt ở cuối
// nếu không có bất kì route nào khớp thì sẽ match vào đây (/Home/Index)
// Home là controller mặc định
// Index là action mặc định
// id? có nghĩa là có thể có hoặc không



app.Run();
