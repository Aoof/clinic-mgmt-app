using ClinicMgmtApp_Project.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClinicMgmtApp_Project.BLL.Utils;
using ClinicMgmtApp_Project.UI;

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
        internal static void DeleteDoctor(int id)
        {
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand("DELETE FROM [dbo].[Doctor] WHERE Id = @Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new UserNotFoundException("Deletion failed");
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();


            }
        }
        internal static void CreateDoctor(Doctor entity)
        {
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand(
                    "INSERT INTO [dbo].[Doctor] (Id, FirstName, LastName, Specialization, Availability) " +
                    "VALUES (@Id, @FirstName, @LastName, @Specialization, @Availability)",
                    sqlConnection);

                sqlCommand.Parameters.AddWithValue("@Id", entity.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                sqlCommand.Parameters.AddWithValue("@Specialization", Doctor.SpecializatioToString(entity.Specialization));
                sqlCommand.Parameters.AddWithValue("@Availability", entity.Availability);

                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new UniqueConstraintViolationException("Creation failed");
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }
        internal static void UpdateDoctor(Doctor entity)
        {
            try
            {
                sqlConnection = DatabaseConnection.GetConnection();
                sqlCommand = new SqlCommand(
                    "UPDATE [dbo].[Doctor] " +
                    "SET FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "Specialization = @Specialization, " +
                    "Availability = @Availability " +
                    "WHERE Id = @Id",
                    sqlConnection);

                sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                sqlCommand.Parameters.AddWithValue("@Specialization", Doctor.SpecializatioToString(entity.Specialization));
                sqlCommand.Parameters.AddWithValue("@Availability", entity.Availability);
                sqlCommand.Parameters.AddWithValue("@Id", entity.Id);

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new UserNotFoundException("Update failed: Doctor not found.");
                }
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

    }
}
