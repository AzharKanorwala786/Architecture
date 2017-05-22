using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
    public class MapViewModels
    {
        public static TOut MapObject<TIn, TOut>(TIn InputObject)
        {
            TOut OutputInstance = Activator.CreateInstance<TOut>();

            IList<string> InputObjectProperties = InputObject.GetType().GetProperties().Select(prop => prop.Name).ToList();

            foreach (PropertyInfo PropInfo in typeof(TOut).GetProperties())
            {
                if (InputObjectProperties.Contains(PropInfo.Name))
                {

                    PropertyInfo propty = InputObject.GetType().GetProperty(PropInfo.Name);
                    object Value = propty.GetValue(InputObject);
                    if (DBNull.Value.Equals(Value))
                    {

                        PropInfo.SetValue(OutputInstance, null, null);
                    }
                    else
                    {
                        PropInfo.SetValue(OutputInstance, Value, null);
                    }
                }
            }
            return OutputInstance;
        }
    }
}
