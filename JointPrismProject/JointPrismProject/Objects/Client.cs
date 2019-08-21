using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JointPrismProject.Objects
{
    public class Client
    {
        //Client ID
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //Client name
        public string Name { get; set; }

        //Client Phone Number
        public string Phone { get; set; }

        //Client Address
        public string Address { get; set; }
    }
}
