using Microsoft.AspNetCore.Mvc;
using actualizar_curp.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;


namespace actualizar_curp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatosPersonalesContext _ctx;

        public HomeController(DatosPersonalesContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BuscarEmpleado(string infoEmpleado)
        {
            var rfcOcurp = infoEmpleado;
            var infoMayusculas = rfcOcurp.ToUpper();
        
            var rfcOcurpValidado = _ctx.empleado.FirstOrDefault(e => e.rfc == infoMayusculas || e.curp == infoMayusculas);

            if (rfcOcurpValidado != null)
            {
                return View("FormActualizarEmpleado", rfcOcurpValidado);
            }
            else
            {
                ViewBag.Mensaje = $"No se encontro este empleado";
                return View("Index");
            }
        }
        
        public IActionResult FormActualizarEmpleado()
        {
            return View();
        }

        public IActionResult ActualizarEmpleado(empleado ActualizarEmpleado)
        {
      
                try
                {
                    var empleado = _ctx.empleado.FirstOrDefault(e => e.Id == ActualizarEmpleado.Id);
                if (empleado != null)
                {
                    empleado.nemp = ActualizarEmpleado.nemp;
                    empleado.curp = ActualizarEmpleado.curp;
                    empleado.nombre = ActualizarEmpleado.nombre;
                    empleado.fechaNacimiento = ActualizarEmpleado.fechaNacimiento;
                    empleado.lugarNacimiento = ActualizarEmpleado.lugarNacimiento;
                    empleado.genero = ActualizarEmpleado.genero;
                    empleado.nacionalidad = ActualizarEmpleado.nacionalidad;
                    empleado.NOMINA = ActualizarEmpleado.NOMINA;
                    empleado.Telefono = ActualizarEmpleado.Telefono;
                    empleado.Celular = ActualizarEmpleado.Celular;
                    empleado.correo = ActualizarEmpleado.correo;
                    empleado.calle = ActualizarEmpleado.calle;
                    empleado.entreCalles = ActualizarEmpleado.entreCalles;
                    empleado.numero = ActualizarEmpleado.numero;
                    empleado.colonia = ActualizarEmpleado.colonia;
                    empleado.municipio = ActualizarEmpleado.municipio;
                    empleado.cp = ActualizarEmpleado.cp;
                    empleado.estadoCivil = ActualizarEmpleado.estadoCivil;
                    empleado.Escolaridad = ActualizarEmpleado.Escolaridad;
                    empleado.Escolaridad2 = ActualizarEmpleado.Escolaridad2;
                    empleado.tieneEspecialidad = ActualizarEmpleado.tieneEspecialidad;
                    empleado.Especialidad = ActualizarEmpleado.Especialidad;
                    empleado.estudiaActualmente = ActualizarEmpleado.estudiaActualmente;
                    empleado.queEstudia = ActualizarEmpleado.queEstudia;
                    empleado.ubicacionLaboral = ActualizarEmpleado.ubicacionLaboral;
                    empleado.puestoFuncional = ActualizarEmpleado.puestoFuncional;
                    empleado.funcion1 = ActualizarEmpleado.funcion1;
                    empleado.funcion2 = ActualizarEmpleado.funcion2;
                    empleado.funcion3 = ActualizarEmpleado.funcion3;
                    empleado.tieneDiscapacidad = ActualizarEmpleado.tieneDiscapacidad;
                    empleado.tipoDiscapacidad = ActualizarEmpleado.tipoDiscapacidad;
                    empleado.jornada = ActualizarEmpleado.jornada;
                    empleado.otraJornada = ActualizarEmpleado.otraJornada;
                    empleado.origenEtnico = ActualizarEmpleado.origenEtnico;
                    empleado.diasTrabajo = ActualizarEmpleado.diasTrabajo;
                    empleado.turnoLaboral = ActualizarEmpleado.turnoLaboral;
                    empleado.horario = ActualizarEmpleado.horario;
                    empleado.CALLESAT = ActualizarEmpleado.CALLESAT;
                    empleado.NUMEROSAT = ActualizarEmpleado.NUMEROSAT;
                    empleado.CPSAT = ActualizarEmpleado.CPSAT;
                    empleado.ESTATUSENELPADRON = ActualizarEmpleado.ESTATUSENELPADRON;
                    empleado.NOTAS = ActualizarEmpleado.NOTAS;
                    empleado.DCTO = ActualizarEmpleado.DCTO;
                    empleado.DE = ActualizarEmpleado.DE;
                    empleado.OpcionesEscolaridad = ActualizarEmpleado.OpcionesEscolaridad;
                }
                    _ctx.Update(empleado);
                    _ctx.SaveChanges();
                    return View("FormActualizarEmpleado", empleado);
                }
                catch (DbUpdateException ex)
                {
                    return BadRequest($"Error al conectar a la base de datos: {ex.Message}");
                }
        }


        public IActionResult ExportarExcelUsuario(empleado empleado)
        {
            var registro = _ctx.empleado.FirstOrDefault(e => e.Id == empleado.Id);

            if (registro == null)
            {
                return NotFound(); 
            }

            SLDocument sl = new SLDocument();

            sl.SetCellValue(1, 1, "Captura");
            sl.SetCellValue(1, 2, "Número de empleado");
            sl.SetCellValue(1, 3, "RFC");
            sl.SetCellValue(1, 4, "CURP");
            sl.SetCellValue(1, 5, "Nombre");
            sl.SetCellValue(1, 6, "Nomina");
            sl.SetCellValue(1, 7, "Teléfono");
            sl.SetCellValue(1, 8, "Celular");
            sl.SetCellValue(1, 9, "Correo");
            sl.SetCellValue(1, 10, "Calle");
            sl.SetCellValue(1, 11, "Numero");
            sl.SetCellValue(1, 12, "Código postal");
            sl.SetCellValue(1, 13, "Escolaridad");
            sl.SetCellValue(1, 14, "Otra escolaridad");
            sl.SetCellValue(1, 15, "Especialidad");
            sl.SetCellValue(1, 16, "Calle SAT");
            sl.SetCellValue(1, 17, "Número SAT");
            sl.SetCellValue(1, 18, "Código postal SAT");
            sl.SetCellValue(1, 19, "Estatus en el padrón");
            sl.SetCellValue(1, 20, "Notas");
            sl.SetCellValue(1, 21, "DCTO");
            sl.SetCellValue(1, 22, "DE");
            sl.SetCellValue(1, 23, "Opciones escolaridad");
            sl.SetCellValue(2, 1, registro.Capturo);
            sl.SetCellValue(2, 2, registro.nemp);
            sl.SetCellValue(2, 3, registro.rfc);
            sl.SetCellValue(2, 4, registro.curp);
            sl.SetCellValue(2, 5, registro.nombre);
            sl.SetCellValue(2, 6, registro.NOMINA);
            sl.SetCellValue(2, 7, registro.Telefono);
            sl.SetCellValue(2, 8, Convert.ToDouble(registro.Celular));
            sl.SetCellValue(2, 9, registro.correo);
            sl.SetCellValue(2, 10, registro.calle);
            sl.SetCellValue(2, 11, registro.numero);
            sl.SetCellValue(2, 12, Convert.ToDouble(registro.cp));
            sl.SetCellValue(2, 13, registro.Escolaridad);
            sl.SetCellValue(2, 14, registro.Escolaridad2);
            sl.SetCellValue(2, 15, registro.Especialidad);
            sl.SetCellValue(2, 16, registro.CALLESAT);
            sl.SetCellValue(2, 17, registro.NUMEROSAT);
            sl.SetCellValue(2, 18, registro.CPSAT);
            sl.SetCellValue(2, 19, registro.ESTATUSENELPADRON);
            sl.SetCellValue(2, 20, registro.NOTAS);
            sl.SetCellValue(2, 21, registro.DCTO);
            sl.SetCellValue(2, 22, registro.DE);
            sl.SetCellValue(2, 23, registro.OpcionesEscolaridad);


            MemoryStream memoryStream = new MemoryStream();
            sl.SaveAs(memoryStream);

            Response.Headers.Add("Content-Disposition", "attachment; filename=" + registro.rfc + ".xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.Body.WriteAsync(memoryStream.ToArray());

            return new EmptyResult();
        }

        public IActionResult ExportarExcel(empleado empleado)
        {
            var registro = _ctx.empleado.FirstOrDefault(e => e.Id == empleado.Id);

            if (registro == null)
            {
                return NotFound();
            }

            SLDocument sl = new SLDocument();

            sl.SetCellValue(1, 1, "Captura");
            sl.SetCellValue(1, 2, "Número de empleado");
            sl.SetCellValue(1, 3, "RFC");
            sl.SetCellValue(1, 4, "CURP");
            sl.SetCellValue(1, 5, "Nombre");
            sl.SetCellValue(1, 6, "Nomina");
            sl.SetCellValue(1, 7, "Teléfono");
            sl.SetCellValue(1, 8, "Celular");
            sl.SetCellValue(1, 9, "Correo");
            sl.SetCellValue(1, 10, "Calle");
            sl.SetCellValue(1, 11, "Numero");
            sl.SetCellValue(1, 12, "Código postal");
            sl.SetCellValue(1, 13, "Escolaridad");
            sl.SetCellValue(1, 14, "Otra escolaridad");
            sl.SetCellValue(1, 15, "Especialidad");
            sl.SetCellValue(1, 16, "Calle SAT");
            sl.SetCellValue(1, 17, "Número SAT");
            sl.SetCellValue(1, 18, "Código postal SAT");
            sl.SetCellValue(1, 19, "Estatus en el padrón");
            sl.SetCellValue(1, 20, "Notas");
            sl.SetCellValue(1, 21, "DCTO");
            sl.SetCellValue(1, 22, "DE");
            sl.SetCellValue(1, 23, "Opciones escolaridad");
            sl.SetCellValue(2, 1, registro.Capturo);
            sl.SetCellValue(2, 2, registro.nemp);
            sl.SetCellValue(2, 3, registro.rfc);
            sl.SetCellValue(2, 4, registro.curp);
            sl.SetCellValue(2, 5, registro.nombre);
            sl.SetCellValue(2, 6, registro.NOMINA);
            sl.SetCellValue(2, 7, registro.Telefono);
            sl.SetCellValue(2, 8, Convert.ToDouble(registro.Celular));
            sl.SetCellValue(2, 9, registro.correo);
            sl.SetCellValue(2, 10, registro.calle);
            sl.SetCellValue(2, 11, registro.numero);
            sl.SetCellValue(2, 12, Convert.ToDouble(registro.cp));
            sl.SetCellValue(2, 13, registro.Escolaridad);
            sl.SetCellValue(2, 14, registro.Escolaridad2);
            sl.SetCellValue(2, 15, registro.Especialidad);
            sl.SetCellValue(2, 16, registro.CALLESAT);
            sl.SetCellValue(2, 17, registro.NUMEROSAT);
            sl.SetCellValue(2, 18, registro.CPSAT);
            sl.SetCellValue(2, 19, registro.ESTATUSENELPADRON);
            sl.SetCellValue(2, 20, registro.NOTAS);
            sl.SetCellValue(2, 21, registro.DCTO);
            sl.SetCellValue(2, 22, registro.DE);
            sl.SetCellValue(2, 23, registro.OpcionesEscolaridad);


            MemoryStream memoryStream = new MemoryStream();
            sl.SaveAs(memoryStream);

            Response.Headers.Add("Content-Disposition", "attachment; filename=" + registro.rfc + ".xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.Body.WriteAsync(memoryStream.ToArray());

            return new EmptyResult();
        }
    }
}


