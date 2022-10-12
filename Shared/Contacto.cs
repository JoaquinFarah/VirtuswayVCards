using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuswayVCards.Shared
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Cargo { get; set; }
        public string Foto { get; set; }
    }
}
