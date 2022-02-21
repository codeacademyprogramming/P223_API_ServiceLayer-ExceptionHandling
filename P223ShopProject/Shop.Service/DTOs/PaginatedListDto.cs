using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.DTOs
{
    public class PaginatedListDto<TItem>
    {

        public PaginatedListDto(List<TItem> items,int count,int pageSize,int pageIndex)
        {
            this.PageIndex = pageIndex;
            this.TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            this.Items.AddRange(items);
        }
        public List<TItem> Items { get; set; } = new List<TItem>();
        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
        public bool HasNext => PageIndex < TotalPage;
        public bool HasPrev => PageIndex > 1;
    }
}
