namespace Sodimac.SCPRO.Model.DataTransferObject
{
    public class RequestPaginationDto : ServiceModelDto
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
