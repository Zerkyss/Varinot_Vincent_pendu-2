using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Varinot_Vincent_pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {
                string[] mots = { "pomme", "banane", "cerise", "datte", "figue", "raisin", "kiwi", "citron", "melon", "orange" };
                string motADeviner = ChoisirMotAleatoire(mots);
                char[] motCache = new char[motADeviner.Length];
                int tentativesRestantes = 6;
                bool jeuGagne = false;

                for (int i = 0; i < motCache.Length; i++)
                {
                    motCache[i] = '_';
                }

                Console.WriteLine("Bienvenue au jeu du Pendu !");
                Console.WriteLine("Vous avez 6 tentatives pour deviner le mot.");

                while (tentativesRestantes > 0)
                {
                    Console.WriteLine("\nMot : " + new string(motCache));
                    Console.WriteLine("Tentatives restantes : " + tentativesRestantes);
                    Console.Write("Devinez une lettre : ");
                    char lettre = Console.ReadLine()[0];

                    if (motADeviner.Contains(lettre))
                    {
                        for (int i = 0; i < motADeviner.Length; i++)
                        {
                            if (motADeviner[i] == lettre)
                            {
                                motCache[i] = lettre;
                            }
                        }

                        if (new string(motCache) == motADeviner)
                        {
                            jeuGagne = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lettre incorrecte.");
                        tentativesRestantes--;
                    }
                }

                if (jeuGagne)
                {
                    Console.WriteLine("Félicitations ! Vous avez deviné le mot : " + motADeviner);
                }
                else
                {
                    Console.WriteLine("Vous avez épuisé toutes vos tentatives. Le mot était : " + motADeviner);
                }
            }
        }

        private static string ChoisirMotAleatoire(string[] mots)
        {
            Random random = new Random();
            int index = random.Next(0, mots.Length);
            return mots[index];
        }
    }
}