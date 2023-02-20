using AutoMapper;
using Sodimac.SCPRO.Model.DataTransferObject.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject.Master;
using Sodimac.SCPRO.Model.Master;
using Sodimac.SCPRO.ViewModel.ClientePRO;
using Sodimac.SCPRO.ViewModel.Master;
using Sodimac.SCPRO.Model.ClientePRO;
using Sodimac.SCPRO.Model.DataTransferObject;
using Sodimac.SCPRO.ViewModel;

namespace Sodimac.SCPRO.WebApi.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            #region Mapping Class to Dto
            CreateMap<NivelEducativo, EducationalLevelDto>();
            CreateMap<Oficio, TradeDto>();
            CreateMap<Sexo, SexDto>();
            CreateMap<TipoDocumentoIdentidad, TypeIdentityDocumentDto>();
            CreateMap<Ubigeo, UbigeoDto>();
            CreateMap<Canal, ChannelDto>();
            CreateMap<Tienda, StoreDto>();
            CreateMap<EstadoSolicitud, RequestStatusDto>();
            CreateMap<Solicitud, RequestDto>();
            CreateMap<RazonDesinscripcion, ReasonDisinscriptionDto>();
            CreateMap<Desinscripcion, DisinscriptionDto>();
            #endregion

            #region Mapping Dto to Class
            CreateMap<EducationalLevelDto, NivelEducativo>();
            CreateMap<TradeDto, Oficio>();
            CreateMap<SexDto, Sexo>();
            CreateMap<TypeIdentityDocumentDto, TipoDocumentoIdentidad>();
            CreateMap<UbigeoDto, Ubigeo>();
            CreateMap<RequestStatusDto, EstadoSolicitud>();
            CreateMap<RequestDto, Solicitud>();
            CreateMap<ChannelDto, Canal>();
            CreateMap<ReasonDisinscriptionDto, RazonDesinscripcion>();
            CreateMap<DisinscriptionDto, Desinscripcion>();
            #endregion

            #region Mapping Dto to View
            CreateMap<ResponsePaginationDto, ResponsePaginationViewModel>();
            CreateMap<RequestPaginationDto, RequestPaginationViewModel>();

            CreateMap<EducationalLevelDto, EducationalLevelViewModel>()
                .ForMember(dest => dest.EducationalLevelId, src => src.MapFrom(enty => enty.NivelEducativoId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListEducationalLevelDto, ListEducationalLevelViewModel>();

            CreateMap<TradeDto, TradeViewModel>()
                .ForMember(dest => dest.TradeId, src => src.MapFrom(enty => enty.OficioId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListTradeDto, ListTradeViewModel>();

            CreateMap<SexDto, SexViewModel>()
                .ForMember(dest => dest.SexId, src => src.MapFrom(enty => enty.SexoId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListSexDto, ListSexViewModel>();

            CreateMap<TypeIdentityDocumentDto, TypeIdentityDocumentViewModel>()
                .ForMember(dest => dest.TypeIdentityDocumentId, src => src.MapFrom(enty => enty.TipoDocumentoIdentidadId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListTypeIdentityDocumentDto, ListTypeIdentityDocumentViewModel>();

            CreateMap<UbigeoDto, UbigeoViewModel>()
                .ForMember(dest => dest.UbigeoId, src => src.MapFrom(enty => enty.UbigeoId))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Nombre))
                .ForMember(dest => dest.Nivel, src => src.MapFrom(enty => enty.Nivel))
                .ForMember(dest => dest.PadreId, src => src.MapFrom(enty => enty.PadreId))
                ;
            CreateMap<ListUbigeoDto, ListUbigeoViewModel>();

            CreateMap<RequestDto, RequestViewModel>()
                .ForMember(dest => dest.RequestId, src => src.MapFrom(enty => enty.SolicitudId))
                .ForMember(dest => dest.TypeIdentityDocumentId, src => src.MapFrom(enty => enty.TipoDocumentoIdentidadId))
                .ForMember(dest => dest.DocumentNumberClient, src => src.MapFrom(enty => enty.NumeroDocCliente))
                .ForMember(dest => dest.LastName, src => src.MapFrom(enty => enty.ApellidoCliente))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(enty => enty.NombreCliente))
                .ForMember(dest => dest.Age, src => src.MapFrom(enty => enty.Edad))
                .ForMember(dest => dest.SexId, src => src.MapFrom(enty => enty.SexoId))
                //.ForMember(dest => dest.EducationalLevelId, src => src.MapFrom(enty => enty.NivelEducativoId))
                .ForMember(dest => dest.TradeId, src => src.MapFrom(enty => enty.OficioId))
                .ForMember(dest => dest.UbigeoId, src => src.MapFrom(enty => enty.UbigeoId))
                .ForMember(dest => dest.Email, src => src.MapFrom(enty => enty.Correo))
                .ForMember(dest => dest.Cellphone, src => src.MapFrom(enty => enty.Celular))
                .ForMember(dest => dest.ChannelId, src => src.MapFrom(enty => enty.CanalId))
                .ForMember(dest => dest.StoreId, src => src.MapFrom(enty => enty.TiendaId))
                .ForMember(dest => dest.RequestStatusId, src => src.MapFrom(enty => enty.EstadoSolicitudId))
                ;
            CreateMap<RequestFilterSearchDto, RequestFilterSearchViewModel>();
            CreateMap<RequestSearchDto, RequestSearchViewModel>();

            CreateMap<ChannelDto, ChannelViewModel>()
                .ForMember(dest => dest.ChannelId, src => src.MapFrom(enty => enty.CanalId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListChannelDto, ListChannelViewModel>();

            CreateMap<StoreDto, StoreViewModel>()
                .ForMember(dest => dest.StoreId, src => src.MapFrom(enty => enty.TiendaId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListStoreDto, ListStoreViewModel>();

            CreateMap<RequestDto, RequestEditViewModel>()
                .ForMember(dest => dest.RequestId, src => src.MapFrom(enty => enty.SolicitudId))
                .ForMember(dest => dest.TypeIdentityDocumentId, src => src.MapFrom(enty => enty.TipoDocumentoIdentidadId))
                .ForMember(dest => dest.DocumentNumberClient, src => src.MapFrom(enty => enty.NumeroDocCliente))
                .ForMember(dest => dest.LastName, src => src.MapFrom(enty => enty.ApellidoCliente))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(enty => enty.NombreCliente))
                .ForMember(dest => dest.Age, src => src.MapFrom(enty => enty.Edad))
                .ForMember(dest => dest.SexId, src => src.MapFrom(enty => enty.SexoId))
                .ForMember(dest => dest.TradeId, src => src.MapFrom(enty => enty.OficioId))
                .ForMember(dest => dest.UbigeoId, src => src.MapFrom(enty => enty.UbigeoId))
                .ForMember(dest => dest.Email, src => src.MapFrom(enty => enty.Correo))
                .ForMember(dest => dest.Cellphone, src => src.MapFrom(enty => enty.Celular))
                .ForMember(dest => dest.ChannelId, src => src.MapFrom(enty => enty.CanalId))
                .ForMember(dest => dest.StoreId, src => src.MapFrom(enty => enty.TiendaId))
                ;

            CreateMap<ListChannelDto, ListChannelViewModel>();
            CreateMap<ChannelDto, ChannelViewModel>()
                .ForMember(dest => dest.ChannelId, src => src.MapFrom(enty => enty.CanalId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));

            CreateMap<ReasonDisinscriptionDto, ReasonDisinscriptionViewModel>()
                .ForMember(dest => dest.ReasonDisinscriptionId, src => src.MapFrom(enty => enty.RazonDesinscripcionId))
                .ForMember(dest => dest.Code, src => src.MapFrom(enty => enty.Codigo))
                .ForMember(dest => dest.Name, src => src.MapFrom(enty => enty.Nombre));
            CreateMap<ListReasonDisinscriptionDto, ListReasonDisinscriptionViewModel>();

            CreateMap<DisinscriptionDto, DisinscriptionViewModel>()
                .ForMember(dest => dest.DisinscriptionId, src => src.MapFrom(enty => enty.DesinscripcionId))
                .ForMember(dest => dest.RequestId, src => src.MapFrom(enty => enty.SolicitudId))
                .ForMember(dest => dest.ReasonDisinscriptionId, src => src.MapFrom(enty => enty.RazonDesinscripcionId))
                .ForMember(dest => dest.DisinscriptionDetail, src => src.MapFrom(enty => enty.DesinscripcionDetalle))
                .ForMember(dest => dest.UserProcess, src => src.MapFrom(enty => enty.UsuarioRegistra));

            CreateMap<RequestFilterSearchDto, RequestFilterReportViewModel>();
            CreateMap<RequestSearchDto, RequestReportViewModel>()
                .ForMember(dest => dest.FechaRegistro, src => src.MapFrom(enty => enty.FechaRegistra))
                .ForMember(dest => dest.OrigenRegistro, src => src.MapFrom(enty => enty.Canal))
                .ForMember(dest => dest.TiendaRegistro, src => src.MapFrom(enty => enty.Tienda))
                .ForMember(dest => dest.TipoDocumento, src => src.MapFrom(enty => enty.TipoDocumentoIdentidad))
                .ForMember(dest => dest.NroDocumento, src => src.MapFrom(enty => enty.NumeroDocCliente))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.NombreCliente))
                .ForMember(dest => dest.Apellidos, src => src.MapFrom(enty => enty.ApellidoCliente))
                .ForMember(dest => dest.Oficio, src => src.MapFrom(enty => enty.Oficio))
                .ForMember(dest => dest.Celular, src => src.MapFrom(enty => enty.Celular))
                .ForMember(dest => dest.CorreoElectronico, src => src.MapFrom(enty => enty.Correo));
            #endregion

            #region Mapping View to Dto
            CreateMap<ResponsePaginationViewModel, ResponsePaginationDto>();
            CreateMap<RequestPaginationViewModel, RequestPaginationDto>();

            CreateMap<EducationalLevelViewModel, EducationalLevelDto>()
                .ForMember(dest => dest.NivelEducativoId, src => src.MapFrom(enty => enty.EducationalLevelId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListEducationalLevelViewModel, ListEducationalLevelDto>();

            CreateMap<TradeViewModel, TradeDto>()
                .ForMember(dest => dest.OficioId, src => src.MapFrom(enty => enty.TradeId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListTradeViewModel, ListTradeDto>();

            CreateMap<SexViewModel, SexDto>()
                .ForMember(dest => dest.SexoId, src => src.MapFrom(enty => enty.SexId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListSexViewModel, ListSexDto>();

            CreateMap<TypeIdentityDocumentViewModel, TypeIdentityDocumentDto>()
                .ForMember(dest => dest.TipoDocumentoIdentidadId, src => src.MapFrom(enty => enty.TypeIdentityDocumentId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListTypeIdentityDocumentViewModel, ListTypeIdentityDocumentDto>();

            CreateMap<UbigeoViewModel, UbigeoDto>()
                .ForMember(dest => dest.UbigeoId, src => src.MapFrom(enty => enty.UbigeoId))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Nombre))
                .ForMember(dest => dest.Nivel, src => src.MapFrom(enty => enty.Nivel))
                .ForMember(dest => dest.PadreId, src => src.MapFrom(enty => enty.PadreId))
                ;
            CreateMap<ListUbigeoViewModel, ListUbigeoDto>();

            CreateMap<RequestViewModel, RequestDto>()
                .ForMember(dest => dest.SolicitudId, src => src.MapFrom(enty => enty.RequestId))
                .ForMember(dest => dest.TipoDocumentoIdentidadId, src => src.MapFrom(enty => enty.TypeIdentityDocumentId))
                .ForMember(dest => dest.NumeroDocCliente, src => src.MapFrom(enty => enty.DocumentNumberClient))
                .ForMember(dest => dest.ApellidoCliente, src => src.MapFrom(enty => enty.LastName))
                .ForMember(dest => dest.NombreCliente, src => src.MapFrom(enty => enty.FirstName))
                .ForMember(dest => dest.Edad, src => src.MapFrom(enty => enty.Age))
                .ForMember(dest => dest.SexoId, src => src.MapFrom(enty => enty.SexId))
                //.ForMember(dest => dest.NivelEducativoId, src => src.MapFrom(enty => enty.EducationalLevelId))
                .ForMember(dest => dest.OficioId, src => src.MapFrom(enty => enty.TradeId))
                .ForMember(dest => dest.UbigeoId, src => src.MapFrom(enty => enty.UbigeoId))
                .ForMember(dest => dest.Correo, src => src.MapFrom(enty => enty.Email))
                .ForMember(dest => dest.Celular, src => src.MapFrom(enty => enty.Cellphone))
                .ForMember(dest => dest.CanalId, src => src.MapFrom(enty => enty.ChannelId))
                .ForMember(dest => dest.TiendaId, src => src.MapFrom(enty => enty.StoreId))
                .ForMember(dest => dest.EstadoSolicitudId, src => src.MapFrom(enty => enty.RequestStatusId))
                .ForMember(dest => dest.UsuarioRegistra, src => src.MapFrom(enty => enty.UserProcess))
                .ForMember(dest => dest.UsuarioModifica, src => src.MapFrom(enty => enty.UserProcess));
            CreateMap<RequestFilterViewModel, RequestFilterDto>();


            CreateMap<ChannelViewModel, ChannelDto>()
                .ForMember(dest => dest.CanalId, src => src.MapFrom(enty => enty.ChannelId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListChannelViewModel, ListChannelDto>();

            CreateMap<StoreViewModel, StoreDto>()
                .ForMember(dest => dest.TiendaId, src => src.MapFrom(enty => enty.StoreId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListStoreViewModel, ListStoreDto>();

            CreateMap<ReasonDisinscriptionViewModel, ReasonDisinscriptionDto>()
                .ForMember(dest => dest.RazonDesinscripcionId, src => src.MapFrom(enty => enty.ReasonDisinscriptionId))
                .ForMember(dest => dest.Codigo, src => src.MapFrom(enty => enty.Code))
                .ForMember(dest => dest.Nombre, src => src.MapFrom(enty => enty.Name));
            CreateMap<ListReasonDisinscriptionViewModel, ListReasonDisinscriptionDto>();

            CreateMap<DisinscriptionViewModel, DisinscriptionDto>()
                .ForMember(dest => dest.DesinscripcionId, src => src.MapFrom(enty => enty.DisinscriptionId))
                .ForMember(dest => dest.SolicitudId, src => src.MapFrom(enty => enty.RequestId))
                .ForMember(dest => dest.RazonDesinscripcionId, src => src.MapFrom(enty => enty.ReasonDisinscriptionId))
                .ForMember(dest => dest.DesinscripcionDetalle, src => src.MapFrom(enty => enty.DisinscriptionDetail))
                .ForMember(dest => dest.UsuarioRegistra, src => src.MapFrom(enty => enty.UserProcess));
            ;

            CreateMap<DisinscriptionEvidenceViewModel, DisinscriptionEvidenceDto>()
                .ForMember(dest => dest.DesinscripcionEvidenciaId, src => src.MapFrom(enty => enty.DisinscriptionEvidenceId))
                .ForMember(dest => dest.DesinscripcionId, src => src.MapFrom(enty => enty.DisinscriptionId))
                .ForMember(dest => dest.EvidenciaImagen, src => src.MapFrom(enty => enty.EvidenceImage))
                .ForMember(dest => dest.EvidenciaImagenNombre, src => src.MapFrom(enty => enty.EvidenceImageName));
            #endregion

        }
    }
}