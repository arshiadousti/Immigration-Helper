using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModel
{
    public class TestViewModel
    {
        public Test Test { get; set; }

        public List<Degree> Degrees { get; set; }

        public List<SpentMoney> SpentMoney { get; set; }
    }
}
