using Microsoft.AspNetCore.Components;
using MyBlog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public class MenuBase : ComponentBase
    {
        [Inject]
        public IInformationProvider InformationService { get; set; }

        [CascadingParameter]
        public GitHubUserInfo UserInformation { get; set; }
        protected async override Task OnInitializedAsync()
        {
            UserInformation = await InformationService.GetUserInfoAsync();
        }
    }
}
