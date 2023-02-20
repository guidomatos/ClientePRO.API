using AutoMapper;
using Sodimac.SCPRO.DomainModel.Interface.Master;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sodimac.SCPRO.DomainService.Logic.Master
{
    public class TypeIdentityDocumentLogic
    {
        private readonly ITypeIdentityDocumentRepository _typeIdentityDocument;
        private readonly IMapper _mapper;

        public TypeIdentityDocumentLogic(ITypeIdentityDocumentRepository typeIdentityDocument, IMapper mapper)
        {
            _typeIdentityDocument = typeIdentityDocument;
            _mapper = mapper;
        }

        public async Task<List<TypeIdentityDocumentDto>> GetAll()
        {
            var typeIdentityDocumentsDto = new List<TypeIdentityDocumentDto>();

            var typeIdentityDocuments = await _typeIdentityDocument.ToListAsync(x => x.Activo);
            typeIdentityDocumentsDto.AddRange(from typeIdentityDocument in typeIdentityDocuments
                            let TypeIdentityDocumentDto = _mapper.Map<TypeIdentityDocumentDto>(typeIdentityDocument)
                        select TypeIdentityDocumentDto);
            return typeIdentityDocumentsDto;
        }
    }
}
