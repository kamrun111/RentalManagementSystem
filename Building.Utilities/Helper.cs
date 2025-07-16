using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Building.Utilities
{
    public static class Helper
    {
        public static List<SelectListItem> CreateSelectList<T>(IEnumerable<T> items, string textField, string valueField)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in items)
            {
                var text = item.GetType().GetProperty(textField)?.GetValue(item, null)?.ToString();
                var value = item.GetType().GetProperty(valueField)?.GetValue(item, null)?.ToString();

                if (text != null && value != null)
                {
                    selectList.Add(new SelectListItem { Text = text, Value = value });
                }
            }
            return selectList;
        }
    }
}
