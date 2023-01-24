using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAppFinal.ABMModels
{
    [Table("Users")]
    public class ABMUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string abmNames { get; set; }

        [EmailAddress]
        public string abmEmail { get; set; }
        public string abmUsername { get; set; }
        public string abmPassword { get; set;}
        public string abmProfilePicture { get; set; }
    }
}
