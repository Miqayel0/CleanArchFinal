using System;
using System.Collections.Generic;

namespace CleanArch.Application.Common.Interfaces
{
    public interface IPagedResult<T>
    {
        public List<T> List { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
    }
}
