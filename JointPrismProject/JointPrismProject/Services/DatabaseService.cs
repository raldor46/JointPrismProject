using JointPrismProject.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JointPrismProject.Services
{
    public class DatabaseService
    {
        static public string FolderPath { get; set; }
        static ClientDatabase _clientDatabase { get; set; }
        static public ClientDatabase ClientDatabase
        {
            get
            {
                if( _clientDatabase == null)
                {
                    _clientDatabase = new ClientDatabase(Path.Combine(FolderPath, "Clients.db3"));
                }
                return _clientDatabase;
            }
        }
        static public void Start()
        {
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)); 
        }
    }
}
