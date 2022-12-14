using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAppFinal.ABMModels
{
    internal class ABMAllVehicles
    {
        public ObservableCollection<ABMVehicle> Vehicles { get; set; } = new ObservableCollection<ABMVehicle>();

        public ABMAllVehicles() =>
            LoadVehicles();

        public void LoadVehicles()
        {
            Vehicles.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<ABMVehicle> vehicles = Directory
                .EnumerateFiles(appDataPath, "*vehicles.txt")
                .Select(filename => new ABMVehicle()
                {
                    Filename = filename,
                    abmModelo = File.ReadAllLines(filename)[0],
                    abmMarca = File.ReadAllLines(filename)[1],
                    abmYear = Int32.Parse(File.ReadAllLines(filename)[2]),
                    abmPlaca = File.ReadAllLines(filename)[3],
                    abmPrecio = Double.Parse(File.ReadAllLines(filename)[4]),
                    abmCiudad = File.ReadAllLines(filename)[5],
                    abmPicture = File.ReadAllLines(filename)[6],
                })
                .OrderBy(vehicle => vehicle.abmModelo);

            foreach (ABMVehicle vehicle in vehicles)
                Vehicles.Add(vehicle);
        }
    }
}
