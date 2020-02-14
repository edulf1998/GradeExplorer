using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.WindowsVM
{
  public class VentanaAsignaturasVM : ModelBase
  {
    private Window w { get; set; }

    private Asignatura _asignatura;
    public Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    private ObservableCollection<Profesor> _profesores;
    public ObservableCollection<Profesor> Profesores
    {
      get => _profesores;
      set => SetField(ref _profesores, value);
    }

    private ObservableCollection<Alumno> _todosAlumnos;
    public ObservableCollection<Alumno> TodosAlumnos
    {
      get => _todosAlumnos;
      set => SetField(ref _todosAlumnos, value);
    }

    private ObservableCollection<Alumno> _alumnos;
    public ObservableCollection<Alumno> Alumnos
    {
      get => _alumnos;
      set => SetField(ref _alumnos, value);
    }

    private Profesor _profesor;
    public Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }
    private bool modificando = false;

    public RelayCommand AddAlumnoCommand { get; set; }
    public RelayCommand DeleteAlumnoCommand { get; set; }
    public RelayCommand ConfirmCommand { get; set; }

    public Alumno AlumnoSeleccionado { get; set; }

    public VentanaAsignaturasVM(Window w)
    {
      this.w = w;
      Asignatura = new Asignatura();
      ConfirmCommand = new RelayCommand((a) => Guardar());
      AddAlumnoCommand = new RelayCommand((a) => AddAlumno());
      DeleteAlumnoCommand = new RelayCommand((a) => DeleteAlumno(), (a) => AlumnoSeleccionado != null);
      _profesores = new ObservableCollection<Profesor>();
      _alumnos = new ObservableCollection<Alumno>();
      _todosAlumnos = new ObservableCollection<Alumno>();
      Task.Factory.StartNew(() => ObtenerProfesores());
      Task.Factory.StartNew(() => ObtenerAlumnos());
    }

    public VentanaAsignaturasVM(Asignatura _asignatura, Window w)
    {
      this.w = w;
      Asignatura = _asignatura;
      Profesor = Asignatura.Profesor != null ? Asignatura.Profesor : null;
      modificando = true;
      ConfirmCommand = new RelayCommand((a) => Guardar());
      AddAlumnoCommand = new RelayCommand((a) => AddAlumno());
      DeleteAlumnoCommand = new RelayCommand((a) => DeleteAlumno(), (a) => AlumnoSeleccionado != null);
      ConfirmCommand = new RelayCommand((p) => Guardar());
      _profesores = new ObservableCollection<Profesor>();
      _alumnos = new ObservableCollection<Alumno>();
      _todosAlumnos = new ObservableCollection<Alumno>();
      Task.Factory.StartNew(() => ObtenerProfesores());
      Task.Factory.StartNew(() => ObtenerAlumnos());
    }

    private void AddAlumno()
    {
      VentanaUnAlumno window = new VentanaUnAlumno(TodosAlumnos);
      window.ShowDialog();

      Alumno a = window.Alumno;
      if (a != null)
      {
        using (var c = new SchoolContext())
        {
          Alumno a2 = c.Alumnos.Find(a.Id);
          c.Entry(a2).State = EntityState.Modified;
          Asignatura.Alumnos.Add(a2);
          c.Set<Asignatura>().AddOrUpdate(Asignatura);
          c.SaveChanges();
        }
      }
    }

    private void DeleteAlumno()
    {
      MessageBoxResult dialogResult = MessageBox.Show("¡Esta operación no se puede deshacer!", "¿Borrar matrícula de alumno?", MessageBoxButton.YesNo);
      if (dialogResult == MessageBoxResult.Yes)
      {
        using (var c = new SchoolContext())
        {
          Asignatura.Alumnos.Remove(c.Alumnos.Find(AlumnoSeleccionado.Id));
          c.Entry(Asignatura).State = EntityState.Modified;
          c.SaveChanges();
        }
      }
    }

    private void ObtenerAlumnos()
    {
      if (modificando)
      {
        foreach (Alumno a in Asignatura.Alumnos)
        {
          Alumnos.Add(a);
        }
      }

      using (var c = new SchoolContext())
      {
        var almns = c.Alumnos.Include((a) => a.Asignaturas);
        foreach (Alumno a in almns)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            TodosAlumnos.Add(a);
          }), DispatcherPriority.Background);
        }
      }
    }

    private void ObtenerProfesores()
    {
      using (var c = new SchoolContext())
      {
        if (!modificando)
        {
          Profesor = c.Profesores.First();
        }
        foreach (Profesor p in c.Profesores)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            Profesores.Add(p);
            if (modificando)
            {
              if (p.Id == Asignatura.Profesor.Id)
              {
                Profesor = p;
              }
            }
          }), DispatcherPriority.Background);
        }
      }
    }

    private void Guardar()
    {
      using (var c = new SchoolContext())
      {
        if (modificando)
        {
          c.Set<Asignatura>().AddOrUpdate(Asignatura);
          Profesor p = c.Profesores.Find(Profesor.Id);
          Asignatura.Profesor = p;
        }
        else
        {
          Asignatura.Profesor = c.Profesores.Find(Profesor.Id);
          c.Asignaturas.Add(Asignatura);
        }
        c.SaveChanges();
      }
      w.Close();
    }
  }
}
