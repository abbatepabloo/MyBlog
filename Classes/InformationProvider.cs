using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyBlog.Classes
{
    public class InformationProvider : IInformationProvider
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string repository;

        public InformationProvider(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;

            repository = configuration.GetValue<string>("github:repository");
            if (string.IsNullOrEmpty(repository)) throw new InvalidOperationException("repository name is missing");
        }

        public async Task<GitHubUserInfo> GetUserInfoAsync()
        {
            return await httpClient.GetFromJsonAsync<GitHubUserInfo>($"https://api.github.com/users/{repository}");
        }

        public async Task<List<GitHubContentInfo>> GetContentInfoAsync()
        {
            return await httpClient.GetFromJsonAsync<List<GitHubContentInfo>>($"https://api.github.com/repos/{repository}/MyBlog/contents/Entries");
        }

        public async Task<GitHubEntryInfo> GetEntryInfoAsync(string url)
        {
            return await httpClient.GetFromJsonAsync<GitHubEntryInfo>(url);
        }

        public async Task<GitHubEntryInfo> GetFileContent(string url)
        {
            return await httpClient.GetFromJsonAsync<GitHubEntryInfo>(url);
        }

        public async Task<GitHubCommitInfo> GetCommitInfoAsync(string path)
        {
            var serOpt = new JsonSerializerOptions();
            serOpt.Converters.Add(new DateFormatConverter());
            var commit = await httpClient.GetFromJsonAsync<IEnumerable<GitHubCommitInfo>>($"https://api.github.com/repos/{repository}/myblog/commits?page=1&per_page=1&path={path}", serOpt);
            return commit.FirstOrDefault();
        }
    }
}
