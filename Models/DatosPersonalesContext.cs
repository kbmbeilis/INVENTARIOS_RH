using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace actualizar_curp.Models
{
    public class DatosPersonalesContext : DbContext
    {

        public DatosPersonalesContext(DbContextOptions<DatosPersonalesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<empleado> empleado { get; set; }
    }
}
