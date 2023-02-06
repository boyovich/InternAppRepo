using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Utils
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum e)
        {
            try
            {
                var descriptionAttribute = e.GetType().GetMember(e.ToString())[0];
                var attr = descriptionAttribute.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0]
                   as DescriptionAttribute;
                return attr == null ? e.ToString() : attr.Description;
            }
            catch(IndexOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }          
            return e.ToString();
        }
    }
}
