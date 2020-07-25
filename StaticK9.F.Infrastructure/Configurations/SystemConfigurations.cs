using System;

namespace StaticK9.F.Infrastructure
{
    public class SystemConfigurations: ISystemConfigurations
    {
        public SystemConfigurations()
        {
            SiteName = "Businessica ";
            SiteName = "Realtime MEdia ";
        }

        public string SiteName { get ; set; }
        public string CompanyName { get; set; }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
