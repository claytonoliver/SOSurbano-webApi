using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosUrbano.Test.Helpers
{
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
            public static async Task<string> ObterTokenJwtAsync(HttpClient client, string email, string senha)
            {
                var loginPayload = new
                {
                    email,
                    senha
                };

                var response = await client.PostAsJsonAsync("/api/auth/login", loginPayload);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadFromJsonAsync<JsonElement>();
                return json.GetProperty("token").GetString(); // ou "accessToken" dependendo da sua API
            }

            /// <summary>
            /// Configura o Authorization header com o token JWT
            /// </summary>
            public static async Task AutenticarComoAsync(HttpClient client, string email, string senha)
            {
                var token = await ObterTokenJwtAsync(client, email, senha);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

}
