using GradeExplorer.Utils;
using System;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Ejercicio : INotifyBase
  {
    private int _id;
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _descripcion;
    public string Descripcion
    {
      get; set;
    }

    private DateTime _fechaLimite;
    public DateTime FechaLimite
    {
      get => _fechaLimite;
      set => SetField(ref _fechaLimite, value);
    }

    // Relaciones
    private Asignatura _asignatura;
    public Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    private IList<Nota> _notas;
    public IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }
  }
}
