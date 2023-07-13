using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            context.Videos.Include("Name");
            

            foreach(var vid  in context.Videos)
            {
                Console.WriteLine(vid.Name);
            }
        }
    }
}
