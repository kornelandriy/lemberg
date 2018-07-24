using System.Linq;
using System.Threading.Tasks;
using lemberg.Models;

namespace lemberg.Helpers
{
    public static class DBHelper
    {
        public static async Task AddToDatabase(this PersonViewModel personVM, AppDbContext context)
        {
            await context.Peoples.AddAsync(
                new People {FirstName = personVM.FirstName, LastName = personVM.LastName});
            await context.SaveChangesAsync();

            await context.Marks.AddAsync(new Mark
            {
                Id = context.Peoples.First(p => p.LastName == personVM.LastName).Id,
                Value = personVM.MarkValue
            });
            await context.SaveChangesAsync();
        }
    }
}