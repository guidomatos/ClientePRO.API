using AutoMapper;
using Sodimac.SCPRO.Common.Error;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.DomainService.Interface.Master;
using Sodimac.SCPRO.DomainService.Logic.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Service.Master
{
    public class ReasonDisinscriptionService: IReasonDisinscriptionService
    {
        private readonly ReasonDisinscriptionLogic _reasonDisinscriptionLogic;

        public ReasonDisinscriptionService(IReasonDisinscriptionRepository reasonDisinscriptionRepository, IMapper mapper)
        {
            _reasonDisinscriptionLogic = new ReasonDisinscriptionLogic(reasonDisinscriptionRepository, mapper);
        }

        public async Task<ListReasonDisinscriptionDto> GetAll()
        {
            var response = new ListReasonDisinscriptionDto();
            try
            {
                response.ReasonDisinscriptions = await _reasonDisinscriptionLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}
