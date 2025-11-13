using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClinicMgmtApp_Project.BLL;

namespace ClinicMgmtApp_Project.BLL.Utils
{
    [Serializable]
    internal struct AvailabilityStruct
    {
        private int id;
        private int doctorId;
        private List<List<int>> slots; // [[day, startHour, endHour], ...]
        private DateTime effectiveDate;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public List<List<int>> Slots
        {
            get { return slots; }
            set { slots = value; }
        }

        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public AvailabilityStruct(int id, int doctorId, List<List<int>> slots, DateTime effectiveDate, AvailabilityStruct? next)
        {
            this.id = id;
            this.doctorId = doctorId;
            this.slots = slots;
            this.effectiveDate = effectiveDate;
        }

        public AvailabilityStruct()
        {
            id = 0;
            doctorId = 0;
            slots = new List<List<int>>();
            effectiveDate = DateTime.Now;
        }

        public string ToHexString()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                byte[] bytes = ms.ToArray();
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }

        public static AvailabilityStruct FromHexString(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                return new AvailabilityStruct();
            }
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (AvailabilityStruct)formatter.Deserialize(ms);
            }
        }
    }
}
