using System;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Services
{
    public interface IApiClient
    {
        Uri CreateRequestUri(string relativePath, string queryString = "");
        Task<T> GetAsync<T>(Uri requestUrl);
    }
}