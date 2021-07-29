using Microsoft.AspNetCore.Components;
using MyBlog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public partial class UserInfoComponent
    {
        [CascadingParameter] GitHubUserInfo UserInfo { get; set;  }
        [Parameter]
        public bool ShowAvatar { get; set; } = true;
        [Parameter]
        public bool ShowDetails { get; set; } = true;

    }
}
