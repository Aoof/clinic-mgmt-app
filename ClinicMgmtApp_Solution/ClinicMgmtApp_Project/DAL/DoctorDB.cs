using ClinicMgmtApp_Project.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClinicMgmtApp_Project.DAL
{
    internal class DoctorDB
    {
        private static SqlConnection sqlConnection = null;
        private static SqlCommand sqlCommand = null;

        internal static List<Doctor> GetAllDoctors()
        {
            List<Doctor> Doctors = new List<Doctor>();

            try
            {

                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand("SELECT * FROM [dbo].[Doctor]", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Doctor doctors = new Doctor(
                   Convert.ToInt32(sqlDataReader["Id"]),
                   sqlDataReader["Username"].ToString(),
                   User.StringToRole(sqlDataReader["Role"].ToString()),
                   sqlDataReader["FirstName"].ToString(),
                   sqlDataReader["LastName"].ToString(),
                   Doctor.StringToSpecialization(sqlDataReader["Specialization"].ToString()),
                   sqlDataReader["Availability"].ToString()
               );

                    Doctors.Add(doctors);
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }

            return Doctors;
        }

    }
}
