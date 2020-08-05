﻿using System;
using System.Collections.Generic;

namespace CURSO01.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int Iidespecialidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
