using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBankingV1._0.ViewModels
{
    public class MainPageViewModel
    {
        public USER user { get; set; }
        public List<account> accounts { get; set; }
        public account account { get; set; }
        public List<accountDetail> accountDetails { get; set; }
        public List<deposit> deposits { get; set; }
        public List<expens> espenses { get; set; }
    }
}