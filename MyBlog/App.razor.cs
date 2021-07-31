using Microsoft.AspNetCore.Components;
using MyBlog.Core;
using System.Threading.Tasks;

namespace MyBlog
{
    public partial class App
    {
        [Inject]
        public IInformationProvider InformationService { get; set; }

        public GitHubUserInfo UserInfo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            UserInfo = await InformationService.GetUserInfoAsync();
        }
    }
}
