using System.Collections.Generic;

namespace Vidzy
{
    public class Tag
    {
        public Tag()
        {
            Videos = new List<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
