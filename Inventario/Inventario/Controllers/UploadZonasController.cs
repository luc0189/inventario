using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using Inventario.Data;
using Inventario.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class UploadZonasController : Controller
    {
        private readonly DataContext _dataContext;
        public UploadZonasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index(List<Zonas> zonas = null)
        {
            zonas = zonas == null ? new List<Zonas>() : zonas;

            return View(zonas);
          
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (file == null)
            {
                ViewBag.Message = $"Seleccione un Documento de Excel";
            }
            try
            {
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                var zonas = await this.GetZonasList(file.FileName);
                return Index();
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message}";
                return View();
            }

        }
        private async Task<Zonas> GetZonasList(string fName)
        {
            Zonas students = new Zonas();
            try
            {

                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
                System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        int contadorSave = 0;
                        int contadorUpdate = 0;
                        _dataContext.ChangeTracker.AutoDetectChangesEnabled = false;
                        while (reader.Read())
                        {
                            string autorized = reader.GetValue(5).ToString();
                            string mesa = reader.GetValue(4).ToString();
                            string nOder = reader.GetValue(0).ToString();
                            string fullName = reader.GetValue(1).ToString();
                            string doc = reader.GetValue(2).ToString();
                            string sede = reader.GetValue(3).ToString();
                            string jornada = reader.GetValue(6).ToString();
                            var exits = await _dataContext.Zonas
                                            
                                            .FirstOrDefaultAsync(s => s.NombreZona == doc);

                            if (exits == null)
                            {
                                _dataContext.Zonas.Add(new Zonas()
                                {
                                    //NOrden = nOder,
                                    //FullName = fullName,
                                    //Document = doc,
                                    //AcudienteName = "*",
                                    //DocumentAcu = "*",
                                    //Sedes = await _dataContext.Sedes.FirstAsync(o => o.NameSedes == sede),
                                    //Mesas = mesa,
                                    //AutDelivery = autorized,
                                    //FechaActualización = DateTime.Now,
                                    //Jornada = jornada
                                    //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                                }); contadorSave++;
                            }
                            else
                            {
                                //exits.NOrden = $"{exits.NOrden}, {nOder}";
                                //exits.Document = exits.Document;
                                //exits.sedes2 = $"{exits.sedes2},{sede}";
                                ////exits.Sedes = await _dataContext.Sedes.FirstAsync(o => o.NameSedes == sede);
                                //exits.FullName = exits.FullName;
                                //exits.AcudienteName = exits.AcudienteName;
                                //exits.DocumentAcu = exits.DocumentAcu;
                                //exits.FechaActualización = DateTime.Now;
                                //exits.AutDelivery = $"{exits.AutDelivery}, {autorized}";
                                //exits.Mesas = $"{exits.Mesas}, {mesa}";
                                //exits.Jornada = exits.Jornada;
                                contadorUpdate++;

                            }



                        }
                        _dataContext.ChangeTracker.AutoDetectChangesEnabled = true;
                        _dataContext.ChangeTracker.DetectChanges();

                        await _dataContext.SaveChangesAsync();
                        ViewBag.Success = $"Se Encontraron {reader.RowCount} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";
                    }
                }

                return students;
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";

            }

            return students;

        }
    }
}
