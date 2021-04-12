using System;

namespace ApiRestInfo802
{
    public class CompteEnBanque
    {
        public string ID { get; set; }

        public string Nom { get; set; }

        public string NumeroCompte { get; set; }

        public int Argent { get; set; }
    }

    public class CompteEnBanqueAjouter
    {
        public string Nom { get; set; }

        public string NumeroCompte { get; set; }

        public int Argent { get; set; }
    }
    public class Commande
    {
        public string IDacheteur { get; set; }

        public string IDvendeur { get; set; }

        public int Montant { get; set; }

    }
}
