using ApliClientLib.Abstractions;
using Common;
using System.Text.Json;

namespace ApliClientLib
{
    internal static class ResponseFactory
    {
        public static async Task<BaseResponse> CreateBaseResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return new BaseResponse((int)response.StatusCode);
            else
                return new BaseResponse((int)response.StatusCode, await GetErrorMsgFromResponse(response));
        }

        public static async Task<DataResponse<T>> CreateDataResponse<T>(HttpResponseMessage response, JsonSerializerOptions jsonOptions)
        {
            if (response.IsSuccessStatusCode)
            {
                T data = await GetDataFromResponse<T>(response, jsonOptions);
                return new DataResponse<T>(data, (int)response.StatusCode);
            }
            else
            {
                return new DataResponse<T>(default(T), (int)response.StatusCode, await GetErrorMsgFromResponse(response));
            }
        }

        private static async Task<T> GetDataFromResponse<T>(HttpResponseMessage response, JsonSerializerOptions jsonOptions)
        {
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, jsonOptions);
        }

        private static async Task<string> GetErrorMsgFromResponse(HttpResponseMessage response)
        {
            string result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(result))
                return response.ReasonPhrase;
            else
                return result;
        }
    }
}
