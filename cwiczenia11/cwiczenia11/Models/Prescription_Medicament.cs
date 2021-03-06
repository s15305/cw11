﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia11.Models
{
    public class Prescription_Medicament
    {
		public int IdMedicament { get; set; }
		public int IdPrescription { get; set; }
		public Nullable<int> Dose { get; set; }
		public string Details { get; set; }
		public Medicament Medicament { get; set; }
		public Prescription Prescription { get; set; }
	}
}
