using System;
using System.Collections.Generic;
using System.Text;

namespace StaticK9.F.Infrastructure
{
    public interface ISystemConfigurations
    {

        public void Save();
        public string SiteName { get; set; }
        public string CompanyName { get; set; }

    }
}
