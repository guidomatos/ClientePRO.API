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
    public class TypeIdentityDocumentService: ITypeIdentityDocumentService
    {
        private readonly TypeIdentityDocumentLogic _typeIdentityDocumentLogic;

        public TypeIdentityDocumentService(ITypeIdentityDocumentRepository typeIdentityDocumentRepository, IMapper mapper)
        {
            _typeIdentityDocumentLogic = new TypeIdentityDocumentLogic(typeIdentityDocumentRepository, mapper);
        }

        public async Task<ListTypeIdentityDocumentDto> GetAll()
        {
            var response = new ListTypeIdentityDocumentDto();
            try
            {
                response.TypeIdentityDocuments = await _typeIdentityDocumentLogic.GetAll();
            }
            catch (Exception e)
            {
                response.Error = new ServiceException(e.Message);
            }
            return response;
        }
    }
}
