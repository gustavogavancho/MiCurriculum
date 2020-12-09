using MiCurriculum.COMMON.Entidades;
using MiCurriculum.COMMON.Interfaces;

namespace MiCurriculum.BIZ
{
    public class PerfilManager : GenericManager<Perfil>, IPerfilManager
    {
        public PerfilManager(IGenericRepository<Perfil> repositorio) : base(repositorio)
        {

        }
    }
}
