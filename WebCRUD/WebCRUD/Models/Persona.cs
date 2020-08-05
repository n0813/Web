﻿using System;
using System.Collections.Generic;

namespace WebCRUD.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Doctor = new HashSet<Doctor>();
            Usuario = new HashSet<Usuario>();
        }

        public int Iidpersona { get; set; }
        public string Nombre { get; set; }
        public string Appaterno { get; set; }
        public string Apmaterno { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefonofijo { get; set; }
        public string Telefonocelular { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public int? Iidsexo { get; set; }
        public int? Bdoctor { get; set; }
        public int? Bpaciente { get; set; }
        public int? Bhabilitado { get; set; }
        public string Foto { get; set; }
        public int? Btieneusuario { get; set; }

        public virtual Sexo IidsexoNavigation { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
