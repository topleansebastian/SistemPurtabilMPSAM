using System;
using System.Collections.Generic;
using System.Text;

namespace MPSAM.Mobile4.Services
{
    public static class Database
    {
        //<add name="DefaultConnection" connectionString="Data Source=35.194.168.150;Initial Catalog=SistemPurtabilDB;Persist Security Info=True;User ID=sqlserver;Password=mpsam" providerName="System.Data.SqlClient" />
        public static String ConnectionString = "Server=35.194.168.150;Database=SistemPurtabilDB;Uid=sqlserver;Pwd=mpsam";
        public static String SqlServerConnectionString = "Data Source=35.194.168.150;Initial Catalog=SistemPurtabilDB;Persist Security Info=True;User ID=sqlserver;Password=mpsam";
        public static String SelectAllQuery = "select * from Doctors";
        //public static String SelectAllActivitatiQuery = "select * from "


    }
}
