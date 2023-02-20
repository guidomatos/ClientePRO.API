using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class ReasonDisinscriptionLogic
    {
        private readonly IReasonDisinscriptionRepository _reasonDisinscriptionRepository;
        private readonly IMapper _mapper;

        public ReasonDisinscriptionLogic(IReasonDisinscriptionRepository reasonDisinscriptionRepository, IMapper mapper)
        {
            _reasonDisinscriptionRepository = reasonDisinscriptionRepository;
            _mapper = mapper;
        }

        public async Task<List<ReasonDisinscriptionDto>> GetAll()
        {
            var reasonDisinscriptionsDto = new List<ReasonDisinscriptionDto>();

            var reasonDisinscriptions = await _reasonDisinscriptionRepository.ToListAsync(x => x.Activo);
            reasonDisinscriptionsDto.AddRange(from reasonDisinscription in reasonDisinscriptions
                            let ReasonDisinscriptionDto = _mapper.Map<ReasonDisinscriptionDto>(reasonDisinscription)
                        select ReasonDisinscriptionDto);
            return reasonDisinscriptionsDto;
        }
    }
}
