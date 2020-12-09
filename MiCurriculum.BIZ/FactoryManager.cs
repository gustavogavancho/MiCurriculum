using MiCurriculum.COMMON.Entidades;
using MiCurriculum.COMMON.Interfaces;

namespace MiCurriculum.BIZ
{
    public class FactoryManager
    {
        public FactoryManager(string origen)
        {
            FactoryRepository factoryRepository = new FactoryRepository(origen);
            this.CrearPerfilManager = new PerfilManager(factoryRepository.CrearRepositorio<Perfil>());
        }

        public IPerfilManager CrearPerfilManager { get; }

    }
}
