using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAppFinal.ABMModels
{
    internal class ABMVehicle
    {
        public string Filename { get; set; }
        public string abmModelo { get; set; }
        public string abmMarca { get; set; }
        public int abmYear { get; set; } = 1890;
        public string abmPlaca { get; set; }
        public double abmPrecio { get; set; }
        public string abmCiudad { get; set; }
        public string abmPicture { get; set; }
    }
}
