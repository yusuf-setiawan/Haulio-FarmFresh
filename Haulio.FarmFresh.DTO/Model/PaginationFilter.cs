namespace Haulio.FarmFresh.DTO.Model
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 5;
            this.Search = "";
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 5 ? 5 : pageSize;
            this.Search = "";
        }
    }
}
