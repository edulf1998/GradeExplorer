using GradeExplorer.Utils;
using System;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Ejercicio : INotifyBase
  {
    private int _id;
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _descripcion;
    public virtual string Descripcion
    {
      get => _descripcion;
      set => SetField(ref _descripcion, value);
    }

    private DateTime _fechaLimite;
    public virtual DateTime FechaLimite
    {
      get => _fechaLimite;
      set => SetField(ref _fechaLimite, value);
    }

    // Relaciones
    private Asignatura _asignatura;
    public virtual Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    private IList<Nota> _notas;
    public virtual IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }

    public Ejercicio()
    {
      _notas = new List<Nota>();
    }
  }
}
