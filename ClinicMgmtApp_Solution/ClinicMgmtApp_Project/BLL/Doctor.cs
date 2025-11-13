using System;
using System.Collections.Generic;
using ClinicMgmtApp_Project.BLL.Utils;
using ClinicMgmtApp_Project.DAL;

namespace ClinicMgmtApp_Project.BLL
{
    internal class Doctor : User
    {
        private string firstName;
        private string lastName;
        private DoctorEnum specialization;
        private AvailabilityStruct availability;
        private List<AvailabilityStruct> otherAvailabilties;

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DoctorEnum Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public AvailabilityStruct Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public Doctor() : base()
        {
            FirstName = "";
            LastName = "";
            Specialization = DoctorEnum.Undefined;
            Availability = new AvailabilityStruct();

        }
        public Doctor(int id, string username, string firstName, string lastName, DoctorEnum specialization, AvailabilityStruct availability) : base(id, username, RolesEnum.Doctor)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialization = DoctorEnum.Undefined;
            Availability = availability;
        }
        public Doctor(int id, string username, RolesEnum role, string firstName, string lastName, DoctorEnum specialization, AvailabilityStruct availability) : base(id, username, role)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialization = DoctorEnum.Undefined;
            Availability = availability;
        }
        public Doctor(Doctor other) : base(other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Specialization = other.Specialization;
            Availability = other.Availability;
        }
        public static List<User> GetDoctorUsers()
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: You must be at least a receptionist to retrieve Doctor Users.");
            }
            List<User> allUsers = User.GetAllUsers();
            List<User> doctorUsers = allUsers.FindAll(user => user.Role == RolesEnum.Doctor);
            return doctorUsers;
        }
        public static List<Doctor> GetAllDoctors()
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Receptionist))
            {
                throw new UnauthorizedException("Access denied: You must be at least a receptionist to retrieve all Doctors.");
            }
            return DoctorDB.GetAllDoctors();
        }
        public static DoctorEnum StringToSpecialization(string specializationString)
        {
            if (Enum.TryParse(specializationString, out DoctorEnum specialization))
            {
                return specialization;
            }
            else
            {
                throw new ValidationException("Invalid specialization string: " + specializationString);
            }
        }
        public static string SpecializatioToString(DoctorEnum specialization)
        {
            return specialization.ToString();
        }
        public static void DeleteDoctor(int id)
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: Only Admin users can delete Doctor.");
            }
            DoctorDB.DeleteDoctor(id);
        }
        public static void CreateDoctor(Doctor newDoctor)
        {
            if (!UserStore.GetUser().CanPerformAction(minimumRole: RolesEnum.Administrator))
            {
                throw new UnauthorizedException("Access denied: Only Admin users can register new Doctors.");
            }
            DoctorDB.CreateDoctor(newDoctor);
        }
        public void SetAvailability(DateTime availability)
        {
            if (!UserStore.GetUser().CanPerformAction(RolesEnum.Doctor))
            {
                throw new UnauthorizedException("Only Admin or Doctor can change Avalibility");
            }
        }
    }
}

