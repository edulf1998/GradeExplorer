using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.Views.Windows
{
  /// <summary>
  /// Lógica de interacción para VentanaAlumnos.xaml
  /// </summary>
  public partial class VentanaAlumnos : Window
  {
    private Alumno _alumno;
    public Alumno Alumno { get; set; }

    private ObservableCollection<Asignatura> _asignaturas;
    public ObservableCollection<Asignatura> Asignaturas { get; set; }

    public VentanaAlumnos()
    {
      InitializeComponent();
      _alumno = new Alumno();
      _asignaturas = new ObservableCollection<Asignatura>(_alumno.Asignaturas);
      DataContext = this;
    }

    public VentanaAlumnos(Alumno a)
    {
      InitializeComponent();
      _alumno = a;
      Task.Factory.StartNew(() => ObtenerAsignaturas());
      DataContext = this;
    }

    private void ObtenerAsignaturas()
    {
      using (var factory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = factory.OpenSession())
        {
          var asignaturas = session.CreateQuery("from Asignatura a").List<Asignatura>();
          foreach (Asignatura a in asignaturas)
          {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
              asignaturas.Add(a);
            }), DispatcherPriority.Background);
          }
        }
      }
    }
  }
}
