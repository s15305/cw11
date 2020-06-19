using cwiczenia11.DAL.DTOs.Requests;
using cwiczenia11.DAL.DTOs.Responses;
using cwiczenia11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia11.DAL.Services.DoctorDbService
{
	public class DoctorDbService : IDoctorDbService
	{
		private readonly CodeFirstContext _context;

		public DoctorDbService(CodeFirstContext context)
		{
			_context = context;
		}

		public IEnumerable<GetDoctorResponse> GetAllDoctors()
		{
			if (!_context.Doctors.Any())
			{
				return null;
			}

			List<GetDoctorResponse> responseList = new List<GetDoctorResponse>();
			foreach (Doctor d in _context.Doctors)
			{
				var response = new GetDoctorResponse
				{
					FirstName = d.FirstName,
					LastName = d.LastName,
					Email = d.Email
				};
				responseList.Add(response);
			}

			return responseList;
		}

		public GetDoctorResponse GetDoctor(int id)
		{
			if (!_context.Doctors.Any())
			{
				return null;
			}

			var doc = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).FirstOrDefault();
			var response = new GetDoctorResponse
			{
				FirstName = doc.FirstName,
				LastName = doc.LastName,
				Email = doc.Email
			};

			return response;
		}


		public string InsertDoctor(InsertDoctorRequest request)
		{
			try
			{
				var doc = new Doctor
				{
					FirstName = request.FirstName,
					LastName = request.LastName,
					Email = request.Email
				};

				_context.Doctors.Add(doc);
				_context.SaveChanges();

				return "Doctor with FirstName: " + doc.FirstName + " and LastName: " + doc.LastName + " successfully inserted";

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public string ModifyDoctor(ModifyDoctorRequest request)
		{
			try
			{
				var prevDoc = _context.Doctors.Where(d => d.IdDoctor.Equals(request.Id)).FirstOrDefault();

				prevDoc.FirstName = request.FirstName;
				prevDoc.LastName = request.LastName;
				prevDoc.Email = request.Email;

				_context.Doctors.Update(prevDoc);
				_context.SaveChanges();

				return "Doctor with id: " + request.Id + " successfully modified!";
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}


		public string DeleteDoctor(int id)
		{
			var doc = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).FirstOrDefault();
			_context.Doctors.Remove(doc);
			_context.SaveChanges();

			return "Doctor with id : " + id + " successfullt removed!";

		}
	}
}
