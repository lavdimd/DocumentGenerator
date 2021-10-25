using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.Response
{
    public class PagedResponse<T> : Response<T>
    {
        #region Properties
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new List<T>();
        #endregion

        #region Ctor
        /// <summary>
        /// Paged Response model using data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// 
        public PagedResponse(T data, int totalCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }


        public PagedResponse(T data, bool succeeded, int totalCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
            Data = data;
            Message = null;
            Succeeded = succeeded;
            Errors = null;
        }

        /// <summary>
        /// Paged Response model using a list of items
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedResponse(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalCount > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;
            Items = items;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedResponse()
        {
        }
        #endregion
    }
}
