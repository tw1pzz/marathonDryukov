using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marafon
{
    public static class Util
    {
        private static marathonEntities2 database;

        public static marathonEntities2 db
        {
            get
            {
                if (database == null)
                    database = new marathonEntities2();

                return database;
            }
        }
    }
}
