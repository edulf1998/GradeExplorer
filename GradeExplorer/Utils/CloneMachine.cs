using System;
using System.Reflection;

namespace GradeExplorer.Utils
{
  public static class CloneMachine<T>
  {
    public static T Clone(T existing)
    {
      Type t = typeof(T);
      var fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
      T copy = (T) Activator.CreateInstance(t);
      for (int i = 0; i < fields.Length; i++)
      {
        fields[i].SetValue(copy, fields[i].GetValue(existing));
      }
      return copy;
    }
  }
}
