namespace SmartLibrary.API.Helper
{
    public class PageParams
    {
        public const int MaxPageSize =10000;

        public int PageNumber { get; set; } = 1;
        private int _pageSize =5000; 
        public int PageSize {
            get
            {
                return _pageSize;
            }
            set 
            {
                _pageSize = (value>MaxPageSize)? MaxPageSize : value;
            }
        }
    }
}
