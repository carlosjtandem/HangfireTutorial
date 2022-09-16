using Hangfire;
using HangFire_Library.Entidades;
using HangFire_Library.Servicios;
using Microsoft.AspNetCore.Mvc;


namespace HangFire_Library.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRepositorioPersonas repositorioPersonas;

        public PersonasController(ApplicationDbContext context, IBackgroundJobClient backgroundJobClient,
            IRepositorioPersonas repositorioPersonas)
        {
            this.context = context;
            this.backgroundJobClient = backgroundJobClient;
            this.repositorioPersonas = repositorioPersonas;
        }

        [HttpPost("crear")]
        public ActionResult Crear(string nombrePersona)
        {
            backgroundJobClient.Enqueue(() => repositorioPersonas.AgregarPersona(nombrePersona));
            return Ok();
        }

        [HttpPost("schedule")]
        public ActionResult Schedule(string nombrePersona)
        {
            backgroundJobClient.Schedule(() => Console.WriteLine("El nombre es:" + nombrePersona), TimeSpan.FromMinutes(1));
            return Ok();
        }


    }
}
