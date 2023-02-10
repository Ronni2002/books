namespace Books.Service.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PaginationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
