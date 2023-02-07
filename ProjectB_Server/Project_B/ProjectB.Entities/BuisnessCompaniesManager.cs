using ProjectB.Data.Sql;
using ProjectB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB.Entities
{
    public class BuisnessCompaniesManager
    {

        public DataTable CompaniesTable = new DataTable();
        public DataTable ShowAllCompaniesFromDB()
        {
            CompaniesTable.Clear();
            DS_BuisnessCompanies DS_BuisnessCompanies = new DS_BuisnessCompanies();
            return CompaniesTable = DS_BuisnessCompanies.ReadAllCompaniesFromDB();
        }



        public DataTable CompaniesNames = new DataTable();
        public DataTable ShowAllCompaniesNamesFromDB(string email)
        {
            CompaniesNames.Clear();
            DS_BuisnessCompanies DS_BuisnessCompanies = new DS_BuisnessCompanies();
            return CompaniesNames = DS_BuisnessCompanies.ReadAllCompaniesNamesFromDB(email);
        }



        public int ShowBcCodeByNameFromDB(string Name)
        {
            DS_BuisnessCompanies DS_BuisnessCompanies = new DS_BuisnessCompanies();
            return DS_BuisnessCompanies.ReadBcCodeByNameFromDB(Name);
        }



        public int ShowBcCodeByEmailFromDB(string email)
        {
            DS_BuisnessCompanies DS_BuisnessCompanies = new DS_BuisnessCompanies();
            return DS_BuisnessCompanies.ReadBcCodeByEmailFromDB(email);
        }



        public void SendCompanyToDB(BuisnessCompaniesModel form)
        {
            DS_BuisnessCompanies DS_BuisnessCompanies = new DS_BuisnessCompanies();
            DS_BuisnessCompanies.EnterCompanyToDB(form);
        }
    }
}
