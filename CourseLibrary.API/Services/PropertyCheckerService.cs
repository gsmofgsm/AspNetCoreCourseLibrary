using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            // the fields are seperated by ",", so we split it
            var fieldsAfterSplit = fields.Split(',');

            // check if the requested fields exist on source
            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();

                // use reflection to check if the property can be found on T.
                var propertyInfo = typeof(T)
                    .GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
