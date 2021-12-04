using Ophelia.Models;
using System;
using System.Linq;

namespace Ophelia.Data
{
    public class ParametersRepository : RepositoryGeneric<Parameters>, IParametersRepository, IDisposable
    {
        public ParametersRepository()
        {
        }

        public T GetValueFromByKey<T>(string key)
        {
            try
            {
                var parameter = GetList(new { ParameterKey = key }).FirstOrDefault();

                if (parameter == null) return default;

                if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                {
                    T valye = (T)(object)parameter.ParameterValueInt;
                    return valye;
                }

                if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                {
                    T valye = (T)(object)parameter.ParameterValueBool;
                    return valye;
                }

                if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    T valye = (T)(object)parameter.ParameterValueDate;
                    return valye;
                }

                if (typeof(T) == typeof(string))
                {
                    T valye = (T)(object)parameter.ParameterValueString;
                    return valye;
                }

                throw new ArgumentException("value of T no exists");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IParametersRepository : IRepositoryGeneric<Parameters>, IDisposable
    {
        T GetValueFromByKey<T>(string key);
    }
}