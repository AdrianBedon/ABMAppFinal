using ABMAppFinal.ABMModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAppFinal.ABMData
{
    public class ABMDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public ABMDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<ABMVehicle>();
            conn.CreateTable<ABMUser>();
        }

        public int AddNewVehicle(ABMVehicle vehicle)
        {
            Init();
            int result = conn.Insert(vehicle);
            return result;
        }

        public int UpdateVehicle(ABMVehicle vehicle)
        {
            Init();
            int result = conn.Update(vehicle);
            return result;
        }

        public int DeleteVehicle(ABMVehicle vehicle)
        {
            Init();
            int result = conn.Delete(vehicle);
            return result;
        }

        public List<ABMVehicle> GetAllVehicles()
        {
            Init();
            List<ABMVehicle> vehicles = conn.Table<ABMVehicle>().ToList();
            return vehicles;
        }

        public ABMVehicle GetVehicle(int id)
        {
            ABMVehicle vehic = new ABMVehicle();
            Init();
            List<ABMVehicle> vehicles = conn.Table<ABMVehicle>().ToList();
            foreach (ABMVehicle vehicle in vehicles)
            {
                if (vehicle.Id == id)
                    vehic = vehicle;
            }
            return vehic;
        }

        public List<ABMVehicle> GetVehiclesUser(ABMUser user)
        {
            List<ABMVehicle> vehiclesUser = new List<ABMVehicle>();
            List<ABMVehicle> vehicles = conn.Table<ABMVehicle>().ToList();
            if (user != null)
            {
                foreach (ABMVehicle vehicle in vehicles)
                {
                    if (vehicle.abmUserId == user.Id)
                        vehiclesUser.Add(vehicle);
                }
            }
            return vehiclesUser;
        }

        public int AddNewUser(ABMUser user)
        {
            Init();
            int result = conn.Insert(user);
            return result;
        }

        public int UpdateUser(ABMUser user)
        {
            Init();
            int result = conn.Update(user);
            return result;
        }

        public int DeleteUser(ABMUser user)
        {
            Init();
            int result = conn.Delete(user);
            return result;
        }

        public ABMUser GetUser(string username)
        {
            ABMUser userL = new ABMUser();
            Init();
            List<ABMUser> users = conn.Table<ABMUser>().ToList();
            foreach (ABMUser user in users)
            {
                if (user.abmUsername == username || user.abmEmail == username)
                    userL = user;
            }
            return userL;
        }

    }
}
