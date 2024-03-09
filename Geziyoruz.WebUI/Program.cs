using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Geziyoruz.Business.DependencyResolvers.AutoFac;
using Geziyoruz.Business.DependencyResolvers.Extension;
using Geziyoruz.Business.Insfrastructure.AutoMapper;
using Geziyoruz.DataAccess.Concrete.EntityFrameworkCore.Context;
using Geziyoruz.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BusinessModule()));
builder.Services.Register();

// AutoMapper
var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// AddDbContext
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GeziyoruzContext>(x => x.UseSqlServer(connectionString));

// Identity
builder.Services.AddIdentity<AppUser, AppRole>(
      x => x.Password = new PasswordOptions()
      {
          RequiredLength = 8,
          RequiredUniqueChars = 0,
          RequireLowercase = false,
          RequireUppercase = false,
          RequireNonAlphanumeric = false,
          RequireDigit = false
      }
    ).AddEntityFrameworkStores<GeziyoruzContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
