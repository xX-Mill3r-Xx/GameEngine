﻿using MillerSpaceInvaders.UI;
using System;
using System.Windows.Forms;

namespace MillerSpaceInvaders
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMenuInicial());
        }
    }
}
