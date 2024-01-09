using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace MegaCasting.DBLib.Class
{

    public class User
    {
        private int _Identifier;

        private string _UserName;

        private string _HashedPassword;

        [Key]
        public int Identifier { get => _Identifier; set => _Identifier = value; }
        [Required]
        public string UserName { get => _UserName; set => _UserName = value; }
        [Required]
        public string HashedPassword { get => _HashedPassword; set => _HashedPassword = value; }


    }


}
