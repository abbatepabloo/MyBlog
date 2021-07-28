using Microsoft.AspNetCore.Components;
using myblog.Classes;

namespace myblog
{ 
    public class EntryComponentBase : ComponentBase
    {
        [Parameter]
        public GitHubContentInfo Entry { get; set; }
    }
}