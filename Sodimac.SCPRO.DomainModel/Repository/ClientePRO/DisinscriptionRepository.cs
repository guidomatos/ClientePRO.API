using Sodimac.SCPRO.DomainModel.Common;
using Sodimac.SCPRO.DomainModel.Interface.ClientePRO;
using Sodimac.SCPRO.Model.ClientePRO;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainModel.Repository.ClientePRO
{
    public class DisinscriptionRepository : BaseRepository<Desinscripcion>, IDisinscriptionRepository
    {
        private readonly CommonRepository unitOfWork;

        public DisinscriptionRepository(ScproContext context) : base(context)
        {
            unitOfWork = new CommonRepository(context);
        }

        public async Task<Desinscripcion> AddDisinscription(Desinscripcion desinscripcion)
        {
            unitOfWork.Add(desinscripcion);
            await unitOfWork.SaveChangesAsync();

            return desinscripcion;
        }

        public async Task<Desinscripcion> Remove(Desinscripcion desinscripcion)
        {
            unitOfWork.Remove(desinscripcion);
            await unitOfWork.SaveChangesAsync();
            return desinscripcion;
        }

    }
}