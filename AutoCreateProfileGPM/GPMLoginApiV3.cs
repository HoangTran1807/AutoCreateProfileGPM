using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutoCreateProfileGPM
{
    internal class GPMLoginApiV3
    {
        private const string URL_LOGIN = "/api/v3/profiles/start/{id}";
        private string _apiUrl;

        public GPMLoginApiV3(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<JObject> startProfileAsync(string id)
        {
            // Tạo URL
            string url = _apiUrl + URL_LOGIN.Replace("{id}", id);

            // In URL để kiểm tra
            Console.WriteLine("Request URL: " + url);

            // Gọi hàm HTTP GET
            string res = await httpGetAsync(url);

            // Nếu không có phản hồi
            if (res == null)
            {
                Console.WriteLine("Response is null.");
                return null;
            }

            // Chuyển chuỗi phản hồi thành JSON
            return JObject.Parse(res);
        }

        public async Task<string> httpGetAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    // In mã trạng thái HTTP để kiểm tra
                    Console.WriteLine("HTTP Status: " + response.StatusCode);

                    // Kiểm tra mã trạng thái
                    if (response.IsSuccessStatusCode)
                    {
                        // Trả về nội dung phản hồi dưới dạng chuỗi
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Log trạng thái không thành công
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    // Log chi tiết ngoại lệ nếu có lỗi xảy ra trong quá trình gửi yêu cầu
                    Console.WriteLine("Request error: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    // Log các ngoại lệ khác
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
        }

    }
}
