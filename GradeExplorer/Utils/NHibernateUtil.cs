using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GradeExplorer.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.PropertyChanged;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace GradeExplorer.Utils
{
  public static class NHibernateUtil
  {
    private static ISessionFactory instance;


    private static string baseDbUrl = $@"Data{Path.DirectorySeparatorChar}";
    private static string dbName = "clase";
    private static string dbNumber = "0";
    private static string dbExt = ".db";

    public static ISessionFactory GetSessionFactory()
    {
      if (instance == null)
      {
        if (!Directory.Exists("Data"))
        {
          Directory.CreateDirectory("Data");
        }

        instance = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile($"{baseDbUrl}{dbName}{dbNumber}{dbExt}"))
                
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Alumno>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Asignatura>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Profesor>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Ejercicio>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Nota>())

                .ProxyFactoryFactory<AddPropertyChangedProxyFactoryFactory>()
                .ExposeConfiguration(c => c.SetInterceptor(new AddPropertyChangedInterceptor()))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
      }
      return instance;
    }

    public static void setDbNumber(string nDbNumber)
    {
      dbNumber = nDbNumber;
      instance = null;
    }

    private static void BuildSchema(Configuration cfg)
    {
      new SchemaExport(cfg).Create(false, true);
    }

  }
}
