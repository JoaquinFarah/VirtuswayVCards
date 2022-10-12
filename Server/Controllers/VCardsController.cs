using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Net.Sockets;
using VirtuswayVCards.Server.Data;
using VirtuswayVCards.Shared;

namespace VirtuswayVCards.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VCardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("LoadCsv")]
        public List<Contacto> LoadCsv()
        {
            List<string> Nombre = new List<string>();
            List<string> Apellido = new List<string>();
            List<string> Telefono = new List<string>();
            List<string> Email = new List<string>();
            List<string> Direccion = new List<string>();
            List<string> Pais = new List<string>();
            List<string> Cargo = new List<string>();
            List<string> Foto = new List<string>();
            List<Contacto> Contactos = new List<Contacto>();

            var path = @"D:\Virtusway\Repos\VirtuswayVCards";
            TextFieldParser csvReader = new TextFieldParser(path);
            using (csvReader)
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                while (!csvReader.EndOfData)
                {
                    var line = csvReader.ReadLine();
                    var values = line.Split(',');

                    Nombre.Add(values[0]);
                    Apellido.Add(values[1]);
                    Telefono.Add(values[2]);
                    Email.Add(values[3]);
                    Direccion.Add(values[4]);
                    Pais.Add(values[5]);
                    Cargo.Add(values[6]);
                    Foto.Add(values[7]);

                }

            };
            csvReader.Close();

            foreach (var contacto in Contactos)
            {
                _context.  .Add(contacto);
                _context.SaveChanges();
            }
            return Contactos;
        }

    };
}