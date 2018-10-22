using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bdc.StateRegisterOfTaxpayers
{
    public class StateRegisterOfTaxpayerService
    {
        private const string API_URL_DEFAULT = "http://www.portal.nalog.gov.by/grp/getData?unp={unp}";
        private readonly string _apiUrl;

        public StateRegisterOfTaxpayerService() : this(API_URL_DEFAULT) { }

        public StateRegisterOfTaxpayerService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<Taxpayer> GetTaxpayerAsync(string unp)
        {
            // sometimes (correlation yet to be found) response can be gzipped
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip |
                    DecompressionMethods.Deflate
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                HttpResponseMessage response = await httpClient
                    .GetAsync(GetRequestUrl(unp))
                    .ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // 400 respone - no unp with that number
                    return null;
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException("Error while connecting to tax service");
                }

                var text = await response.Content.ReadAsStringAsync();
                var collection = DeserializeObject<TaxpayerCollection>(text);
                return collection.Taxpayers[0];
            }
        }

        private string GetRequestUrl(string unp)
        {
            return _apiUrl.Replace("{unp}", unp);
        }

        private T DeserializeObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(tr);
            }
        }
    }
}
