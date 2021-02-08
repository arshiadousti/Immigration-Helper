using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModel
{
    public class TestDetailViewModel
    {
        public List<Test> Tests { get; set; }

        public List<CountryTest> CountryTests { get; set; }
    }
}
