using Microsoft.AspNetCore.Components;
using MyBlog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public partial class EntriesComponent : ComponentBase
    {
        [Inject] public IInformationProvider InformationService { get; set; }
        public List<GitHubContentInfo> Entries { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Entries = await InformationService.GetContentInfoAsync();
        }
    }
}
