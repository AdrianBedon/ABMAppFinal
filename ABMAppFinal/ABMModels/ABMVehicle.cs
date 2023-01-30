using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ABMAppFinal.ABMModels
{
    [Table("ABMvehicles")]
    public class ABMVehicle
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string abmModelo { get; set; }
        public string abmMarca { get; set; }
        public int abmYear { get; set; } = 1890;

        [MaxLength(10), Unique]
        public string abmPlaca { get; set; }
        public double abmPrecio { get; set; }
        public string abmCiudad { get; set; }
        public string abmPicture { get; set; }
        public int abmUserId { get; set; }
        public DateTime abmDate { get; set; }
    }
}
