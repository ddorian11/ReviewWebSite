using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewWebSite.Data
{
    public static class DbInitializer
    {
        //se creaza baza de date cand este nevoie
        public static void Initialize(ReviewContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
