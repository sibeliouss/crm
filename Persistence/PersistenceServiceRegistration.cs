using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;
//static metotlar ve sınıflar, bir nesne oluşturulmasına gerek kalmadan doğrudan kullanılabilir.
public static class PersistenceServiceRegistration
{
   public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<BaseDbContext>(opt =>
      {
         opt.UseSqlServer(configuration.GetConnectionString("CRMProject"));
      });

      services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<BaseDbContext>();
      
      services.AddScoped<IActivityRepository, ActivityRepository>();
      services.AddScoped<IContactRepository, ContactRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IOpportunityRepository, OpportunityRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();

   } 
}