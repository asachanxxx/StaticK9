using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StaticK9.F.Infrastructure;

namespace StaticK9.F.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISystemConfigurations _configs;

        public string SiteName = "";
        public IndexModel(ILogger<IndexModel> logger, ISystemConfigurations configs)
        {
            _logger = logger;
            _configs = configs;

            Initialize();
        }

        public void Initialize()
        {
            SiteName = _configs.SiteName;
        }

        public void OnGet()
        {

        }
    }
}
