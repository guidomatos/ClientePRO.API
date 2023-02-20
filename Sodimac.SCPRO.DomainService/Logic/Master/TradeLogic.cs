using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class TradeLogic
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public TradeLogic(ITradeRepository tradeRepository, IMapper mapper)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
        }

        public async Task<List<TradeDto>> GetAll()
        {
            var tradesDto = new List<TradeDto>();

            var trades = await _tradeRepository.ToListAsync(x => x.Activo);
            tradesDto.AddRange(from trade in trades
                            let TradeDto = _mapper.Map<TradeDto>(trade)
                        select TradeDto);
            return tradesDto;
        }
    }
}
