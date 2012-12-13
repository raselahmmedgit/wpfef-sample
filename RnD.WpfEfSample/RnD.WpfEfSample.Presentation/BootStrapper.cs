using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using RnD.WpfEfSample.Data;

namespace RnD.WpfEfSample.Presentation
{
    public static class BootStrapper
    {
        public static void Run()
        {
            InitializeAndSeedDb();
            //SetIocContainer();
        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                string connectionString = GetConnectionString();

                // Initializes and seeds the database.
                Database.SetInitializer(new DbInitializer());

                using (var context = new AppDbContext(connectionString))
                {
                    context.Database.Initialize(force: true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //private static void SetIocContainer()
        //{
        //    try
        //    {
        //        //Implement Autofac

        //        var configuration = GlobalConfiguration.Configuration;
        //        var builder = new ContainerBuilder();

        //        // Register MVC controllers using assembly scanning.
        //        builder.RegisterControllers(Assembly.GetExecutingAssembly());

        //        // Register MVC controller and API controller dependencies per request.
        //        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
        //        builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

        //        // Register service
        //        builder.RegisterAssemblyTypes(typeof(ProfileService).Assembly)
        //        .Where(t => t.Name.EndsWith("Service"))
        //        .AsImplementedInterfaces().InstancePerDependency();

        //        // Register repository
        //        builder.RegisterAssemblyTypes(typeof(ProfileRepository).Assembly)
        //        .Where(t => t.Name.EndsWith("Repository"))
        //        .AsImplementedInterfaces().InstancePerDependency();

        //        var container = builder.Build();

        //        //for MVC Controller Set the dependency resolver implementation.
        //        var resolverMvc = new AutofacDependencyResolver(container);
        //        System.Web.Mvc.DependencyResolver.SetResolver(resolverMvc);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        private static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;

            string providerName = ConfigurationManager.ConnectionStrings["AppDbContext"].ProviderName;

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);



            return connectionString;
        }
    }
}
