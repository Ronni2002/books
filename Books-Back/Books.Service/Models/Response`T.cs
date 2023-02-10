namespace Books.Service.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Succeeded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] Errors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Response() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public Response(T items)
        {
            Items = items;
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Response<T> Create(T items)
        {
            return new Response<T>(items);
        }
    }
}
