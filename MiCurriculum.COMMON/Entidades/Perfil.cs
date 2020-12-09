using MiCurriculum.COMMON.Enumeraciones;
using System;

namespace MiCurriculum.COMMON.Entidades
{
    public class Perfil : BaseEntity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Sexo Sexo { get; set; }
        public byte[] Foto { get; set; }
        public string ResumenProfesional { get; set; }
        public string Dirección { get; set; }
        public long Teléfono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
