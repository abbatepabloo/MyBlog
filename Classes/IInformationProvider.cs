using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Classes
{
    public interface IInformationProvider
    {
        Task<List<GitHubContentInfo>> GetContentInfoAsync();
        Task<GitHubEntryInfo> GetEntryInfoAsync(string url);
        Task<GitHubUserInfo> GetUserInfoAsync();
        Task<GitHubEntryInfo> GetFileContent(string url);
        Task<GitHubCommitInfo> GetCommitInfoAsync(string url);
    }
}