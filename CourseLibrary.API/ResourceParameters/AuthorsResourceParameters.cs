using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ResourceParameters
{
    public class AuthorsResourceParameters
    {
        const int maxPageSize = 20;
        private int _pageSize = 10;

        public string MainCategory { get; set; }
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;  // default is important
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; // max is important
        }

        public string OrderBy { get; set; } = "Name";

        public string Fields { get; set; }
    }
}
