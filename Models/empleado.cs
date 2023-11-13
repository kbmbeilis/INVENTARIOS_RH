using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace actualizar_curp.Models
{
 
    public partial class empleado
    {
        public int Id { get; set; }

        public string? Capturo { get; set; }

        public int nemp { get; set; }

        public string? rfc { get; set; }

        public string? curp { get; set; }

        public string? nombre { get; set; }

        public string? fechaNacimiento { get; set; }

        public string? lugarNacimiento { get; set; }

        public string? genero { get; set; }

        public string? nacionalidad { get; set; }

        public string? NOMINA { get; set; }

        public string? Telefono { get; set; }

        public double? Celular { get; set; }

        public string? correo { get; set; }

        public string? calle { get; set; }

        public string? entreCalles { get; set; }

        public string? numero { get; set; }

        public string? colonia { get; set; }

        public string? municipio { get; set; }

        public int? cp { get; set; }

        public string? estadoCivil { get; set; }

        public string? Escolaridad { get; set; }

        public string? Escolaridad2 { get; set; }

        public string? tieneEspecialidad{ get; set; }

        public string? Especialidad { get; set; }

        public string? estudiaActualmente { get; set; }

        public string? queEstudia { get; set; }

        public string? ubicacionLaboral { get; set; }

        public string? puestoFuncional { get; set; }

        public string? funcion1 { get; set; }

        public string? funcion2 { get; set; }

        public string? funcion3 { get; set; }

        public string? tieneDiscapacidad { get; set; }

        public string? tipoDiscapacidad { get; set; }

        public string? jornada { get; set; }

        public string? otraJornada { get; set; }

        public string? origenEtnico { get; set; }

        public string? diasTrabajo { get; set; }

        public string? turnoLaboral { get; set; }

        public string? horario { get; set; }

        public string? CALLESAT { get; set; }

        public string? NUMEROSAT { get; set; }

        public string? CPSAT { get; set; }

        public string? ESTATUSENELPADRON { get; set; }

        public string? NOTAS { get; set; }

        public string? DCTO { get; set; }

        public string? DE { get; set; }

        public string? OpcionesEscolaridad { get; set; }

        


    }
}
