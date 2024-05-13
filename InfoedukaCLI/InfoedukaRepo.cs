using InfoedukaDto;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace InfoedukaCLI
{
    public class InfoedukaRepo
    {
        const string INFOEDUKA_BASE_URL = "https://student.algebra.hr/digitalnareferada/api/";

        private HttpClient _client;

        public InfoedukaRepo()
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            _client = new HttpClient(handler);
        }

        public async Task Login(string username, string password)
        {
            object req = new
            {
                username,
                password
            };
            await _client.PostAsync($"{INFOEDUKA_BASE_URL}/login", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
        }

        public async Task<InfoedukaResponse> GetInfo()
        {

            var response = await _client.GetAsync("/student/predmeti");
            return new InfoedukaResponse();

        }
    }
}
