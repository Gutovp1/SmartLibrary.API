using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;

namespace SmartLibrary.API.Helper
{
    public class PageList<T>:List<T>
    {
        public PageList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount; 
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount/(double)PageSize) ;
            this.AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PageList<T>> CreateAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToListAsync(); 
            return new PageList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
