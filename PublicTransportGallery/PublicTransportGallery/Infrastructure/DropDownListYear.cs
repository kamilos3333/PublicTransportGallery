using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public static class DropDownListYear
    {
        public static IEnumerable<int> GetYear()
        {
            List<int> years = new List<int>();

            for (int i = DateTime.Now.Year; i >= 1890; i--)
            {
                years.Add(i);
            }

            return years;
        }
    }
}