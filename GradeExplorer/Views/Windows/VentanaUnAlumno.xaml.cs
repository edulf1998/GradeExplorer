using GradeExplorer.Models;
using GradeExplorer.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GradeExplorer.Views.Windows
{
  /// <summary>
  /// Lógica de interacción para VentanaUnAlumno.xaml
  /// </summary>
  public partial class VentanaUnAlumno : Window
  {
    public Alumno Alumno { get; set; }
    public ObservableCollection<Alumno> Alumnos { get; set; }
    public RelayCommand ConfirmCommand {get; set;}

    public VentanaUnAlumno(ObservableCollection<Alumno> alumnos)
    {
      InitializeComponent();
      Alumnos = new ObservableCollection<Alumno>(alumnos);
      ListaAlumnos.ItemsSource = Alumnos;
      ListaAlumnos.SelectedItem = Alumnos.Count > 0 ? Alumnos.First() : null;
      ConfirmCommand = new RelayCommand((p) => Close());
      BtnConfirmar.Command = ConfirmCommand;
    }

    private void SeleccionCambio(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
      Alumno = ListaAlumnos.SelectedItem as Alumno;
    }
  }
}
