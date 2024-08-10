namespace Inoa
{
    class Remetente {
        public string email {get; set;} = String.Empty;
        public string senha {get; set;} = String.Empty;
    }

    class CredenciaisSTMP {
        public string host {get; set;} = String.Empty;
        public int port {get; set; }
        public bool ssl {get; set; }
    }
}