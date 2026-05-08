using sistema_de_ponto_front.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace sistema_de_ponto_front.Services
{
    class ApiService
    {
        // URL da sua API Laravel
        private const string BaseUrl = "http://10.0.2.2:8000/api/";

        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<AuthResponse> Login(string cpf, string password)
        {
            var loginData = new
            {
                cpf = cpf,
                password = password
            };

            var json = JsonSerializer.Serialize(loginData);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                BaseUrl + "login",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new Exception(error);
            }

            var responseJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var authResponse = JsonSerializer.Deserialize<AuthResponse>(
                responseJson,
                options
            );

            return authResponse;
        }
    }
}
