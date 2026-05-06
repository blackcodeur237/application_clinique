using System;
using System.Windows.Forms;
using MyClinic_1._0.src.features.splash;
using MyClinic_1._0.src.features.login;

namespace MyClinic_1._0
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var splash = new SplashView())
            {
                // Affiche le splash en modal ; si DialogResult.OK on continue
                if (splash.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new SplashView());
        }
    }
}
