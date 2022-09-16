using HangFire_Library.Entidades;

namespace HangFire_Library.Servicios
{

    public class RepositorioPersonas : IRepositorioPersonas
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<RepositorioPersonas> logger;

        public RepositorioPersonas(ApplicationDbContext dbContext, ILogger<RepositorioPersonas> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task AgregarPersona(string nombrePersona)
        {
            logger.LogInformation($"agregando a la persona {nombrePersona}");
            var persona = new Persona { Nombre = nombrePersona };
            dbContext.Add(persona);
            await Task.Delay(5000);
            await dbContext.SaveChangesAsync();
            logger.LogInformation($"agregada la persona {nombrePersona}");
        }
    }
}
