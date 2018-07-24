using System.Collections.Generic;
using System.Linq;
using lemberg.Models;

namespace lemberg.Helpers
{
    public static class PageHelper
    {
        public static IEnumerable<People> GetPage(this IEnumerable<People> peoples, int pageIndex, int pageSize)
        {
            return peoples
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }
    }
}