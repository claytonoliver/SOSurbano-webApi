using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosUrbano.Test.Helpers
{
    using global::SosUrbano.Test.Dto;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;

    namespace SosUrbano.Test.Helpers
    {
        public static class AuthHelper
        {
            /// <summary>
            /// Realiza login na API e retorna o token JWT
            /// </summary>
            public static async Task<string> ObterTokenJwtAsync(HttpClient client, RequestLogin login)
            {

                var response = await client.PostAsJsonAsync("/api/auth/login", login);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadFromJsonAsync<JsonElement>();
                return json.GetProperty("token").GetString(); // ou "accessToken" dependendo da sua API
            }

            /// <summary>
            /// Configura o Authorization header com o token JWT
            /// </summary>
            public static async Task AutenticarComoAsync(HttpClient client, RequestLogin login)
            {
                var token = await ObterTokenJwtAsync(client, login);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

}
