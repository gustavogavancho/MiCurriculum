using MiCurriculum.COMMON.Entidades;
using MiCurriculum.COMMON.Interfaces;
using MiCurriculum.DAL.Local.LiteDB;

namespace MiCurriculum.BIZ
{
    public class FactoryRepository
    {
        string _origen;

        public FactoryRepository(string origen)
        {
            _origen = origen;
        }

        public IGenericRepository<T> CrearRepositorio<T>() where T : BaseEntity
        {
            switch (_origen)
            {
                case "LiteDB":
                    return new GenericRepository<T>();
                default:
                    return null;
            }
        }
    }
}
