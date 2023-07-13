using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            var courses = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Level)
                .Select(c => c.Tags);


        }
    }
}
