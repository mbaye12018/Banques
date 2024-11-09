using System;

namespace CompteBanqueNS
{
    /// <summary>
    /// Classe démo compte bancaire.
    /// </summary>
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqué = false;

        private CompteBancaire() { }

        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string NomClient
        {
            get { return m_nomClient; }
        }

        public double Balance
        {
            get { return m_solde; }
        }

        public void Debiter(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }

            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant débité doit être inférieur ou égal au solde disponible");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant doit être positif");
            }

            m_solde -= montant; // correction de l'erreur intentionnelle
        }

        public void Crediter(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant crédité doit être supérieur à 0");
            }

            m_solde -= montant;
        }

        private void BloquerCompte()
        {
            m_bloqué = true;
        }

        private void DebloquerCompte()
        {
            m_bloqué = false;
        }

        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);

            cb.Crediter(500000);
            cb.Debiter(400000);

            Console.WriteLine("Solde disponible égal à {0}", cb.Balance);
        }
    }
}
