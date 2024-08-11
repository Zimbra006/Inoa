/*
    Classe que utiliza a API da Brapi para a consulta da cotação
    dos ativos. Nota: os dados tem um atraso de 30 minutos.
*/

using System.Text.Json;

namespace Inoa
{
    class DadosAtivo
    {
        private readonly HttpClient httpClient = new();
        private readonly string urlBase = "https://brapi.dev/api/quote/";
        private readonly string apiKey = "7ekSvuCadR7rYhLdCXFrRn";

        public async Task<string> GetDadosAtivo(string ticker)
        {
            string QUERY_URL = $"{urlBase}{ticker}?range=1d&interval=1d&token={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(QUERY_URL);

                return await response.Content.ReadAsStringAsync();
            }   
        }

        public Ativo GetPrecoAtivo(string ticker)
        {
            string json_data = this.GetDadosAtivo(ticker).Result;

            ResultsJson? resultsJson = JsonSerializer.Deserialize<ResultsJson>(json_data);

            if (resultsJson != null)
            {
                return resultsJson.results[0];
            }

            return new Ativo(0);
        }
    }
}