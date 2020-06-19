using cwiczenia11.DAL.DTOs.Requests;
using cwiczenia11.DAL.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia11.DAL.Services.DoctorDbService
{
    public interface IDoctorDbService
    {
        public GetDoctorResponse GetDoctor(int id);
        public IEnumerable<GetDoctorResponse> GetAllDoctors();

        public string DeleteDoctor(int id);
        public string InsertDoctor(InsertDoctorRequest request);
        public string ModifyDoctor(ModifyDoctorRequest request);
    }
}
