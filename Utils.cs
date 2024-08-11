/*
    Classes de utilidade geral, feitas para ajudar na execução do resto do código.
*/

namespace Inoa
{
    class Remetente {
        public string email {get; set;} = String.Empty;
        public string senha {get; set;} = String.Empty;
    }

    class CredenciaisSMTP {
        public string host {get; set;} = String.Empty;
        public int port {get; set; }
        public bool ssl {get; set; }
    }

    class Ativo(double regularMarketPrice) {
        public double regularMarketPrice {get; set;} = regularMarketPrice;
    }

    class ResultsJson(List<Ativo> results, string requestedAt, string took) {
        public List<Ativo> results {get; set;} = results;
        public string requestedAt {get; set;} = requestedAt;
        public string took {get; set;} = took;
    }
}