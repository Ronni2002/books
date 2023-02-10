namespace Books.Service.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PagedResponse<T> : Response<T>
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
        public int TotalPages { get; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalRecords"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedResponse(T items, int totalRecords, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)PageSize));
            Items = items;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedResponse(string[] errors, string message)
        {
            Errors = errors;
            Message = message;
            Succeeded = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static PagedResponse<T> Create(T items, int totalRecords, int pageNumber, int pageSize)
        {
            return new PagedResponse<T>(items, totalRecords, pageNumber, pageSize);
        }

        public static PagedResponse<T> CreateWithErrors(string[] errors, string message)
        {
            return new PagedResponse<T>(errors, message);
        }
    }
}
