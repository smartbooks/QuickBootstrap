using System.Collections.Generic;

namespace QuickBootstrap.Services.Util
{
    public sealed class PagedResult<T> : Paged where T : class
    {
        public IList<T> Result { get; set; }

        public PagedResult()
        {
            Result = new List<T>();
        }
    }
}