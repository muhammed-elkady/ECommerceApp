using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Core.Specifications
{
    public class ProductParams
    {

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

        // Page Size
        private const int MaximumPageSize = 50;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaximumPageSize) ? MaximumPageSize : value;
        }

        // Page Index
        public int PageIndex { get; set; } = 1;

        private string _search;
        public string Search
        {
            get => _search;
            set => value.ToLower();
        }


    }
}
