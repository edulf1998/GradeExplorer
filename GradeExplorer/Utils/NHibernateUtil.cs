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
                .Database(SQLiteConfiguration.Standard.UsingFile($@"Data{Path.DirectorySeparatorChar}clase.db"))
                
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Profesor>())



                .ProxyFactoryFactory<AddPropertyChangedProxyFactoryFactory>()
                .ExposeConfiguration(c => c.SetInterceptor(new AddPropertyChangedInterceptor()))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
      }
      return instance;
    }

    private static void BuildSchema(Configuration cfg)
    {
      new SchemaExport(cfg).Create(false, true);
    }
  }
}
