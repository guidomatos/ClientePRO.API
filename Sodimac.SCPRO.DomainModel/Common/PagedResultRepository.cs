using System;
using System.Collections.Generic;
using System.Text;

namespace Sodimac.SCPRO.DomainModel.Common
{
    public class PagedResultRepository<T> : PagedResultBaseRepository where T : class
    {
        public IList<T> Results { get; set; }
        public T Result { get; set; }
        public PagedResultRepository()
        {
            Results = new List<T>();
        }
    }
}