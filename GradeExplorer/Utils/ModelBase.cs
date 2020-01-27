using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeExplorer.Utils
{
  public class ModelBase : INotifyPropertyChanged, ICloneable
  {
    public virtual event PropertyChangedEventHandler PropertyChanged;
    public virtual object Clone()
    {
      return new { };
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(field, value)) return false;
      field = value;
      OnPropertyChanged(propertyName);

      return true;
    }
  }
}
