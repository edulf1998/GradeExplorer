using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GradeExplorer.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace GradeExplorer.Utils
{
  public static class NHibernate
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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Alumno>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Asignatura>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Ejercicio>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Profesor>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Nota>())
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
