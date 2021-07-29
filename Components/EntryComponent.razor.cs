using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlog.Classes;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

// Credits: https://blog.ladeak.net/posts/blazor-code-highlight
// https://www.meziantou.net/publishing-a-blazor-webassembly-application-to-github-pages.htm

namespace MyBlog
{
    public class EntryComponentBase : ComponentBase
    {
        [Inject] protected IInformationProvider InformationService { get; set; }
        [Inject] protected IJSRuntime JsInterop { get; set; }

        [Parameter]
        public GitHubContentInfo Entry { get; set; }
        public GitHubCommitInfo CommitInfo { get; set; }

        protected MarkupString HtmlContent;

        protected async override Task OnParametersSetAsync()
        {
            var entryInfo = await InformationService.GetFileContent(Entry.git_url);
            CommitInfo = await InformationService.GetCommitInfoAsync(Entry.path);

            if (!string.IsNullOrEmpty(entryInfo.content))
            {
                HtmlContent = new MarkupString(Markdig.Markdown.ToHtml(Encoding.UTF8.GetString(Convert.FromBase64String(entryInfo.content))));
            }
            else
            {
                HtmlContent = new MarkupString("<h5>No information found!</h5>");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsInterop.InvokeVoidAsync("Prism.highlightAll");
        }
    }
}