using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuyingApartment
{
    internal class ProjectContext
    {
        public FormData FormData { get; private set; }
        public static ProjectContext Instance { get; private set; }

        private ProjectContext()
        { 
            FormData = new FormData();
        }

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new ProjectContext();
            }
        }

    }
}
