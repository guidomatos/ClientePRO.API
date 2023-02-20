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
    public class TradeService : ITradeService
    {
        private readonly TradeLogic _tradeLogic;

        public TradeService(ITradeRepository tradeLevelRepository, IMapper mapper)
        {
            _tradeLogic = new TradeLogic(tradeLevelRepository, mapper);
        }

        public async Task<ListTradeDto> GetAll()
        {
            var response = new ListTradeDto();
            try
            {
                response.Trades = await _tradeLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}
