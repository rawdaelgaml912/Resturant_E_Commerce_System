using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Restaurant_Project.Services
{
    public class PaymobService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PaymobService(
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string> CreatePaymentIntention(
            decimal amount,
            string fullName,
            string phone,
            string address)
        {
            var secretKey =
                _configuration["Paymob:SecretKey"];

            var integrationId =
                _configuration["Paymob:IntegrationId"];

            var request = new
            {
                amount = (int)(amount * 100),

                currency = "EGP",

                payment_methods = new[]
                {
                    int.Parse(integrationId!)
                },

                billing_data = new
                {
                    apartment = "NA",
                    email = "customer@example.com",
                    floor = "NA",
                    first_name = fullName,
                    street = address,
                    building = "NA",
                    phone_number = phone,
                    shipping_method = "NA",
                    postal_code = "NA",
                    city = "Cairo",
                    country = "EG",
                    last_name = "Customer",
                    state = "Cairo"
                }
            };

            var json =
                JsonSerializer.Serialize(request);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Token",
                    secretKey
                );

            var response =
                await _httpClient.PostAsync(
                    "https://accept.paymob.com/v1/intention/",
                    content
                );

            var responseContent =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Paymob Error: {responseContent}"
                );
            }

            using var document =
                JsonDocument.Parse(responseContent);

            var clientSecret =
                document.RootElement
                    .GetProperty("client_secret")
                    .GetString();

            return clientSecret!;
        }
    }
}