using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Helpers
{
    public static class Senha
    {
        public static string Gerar()
        {
            string chars = "abcdefghjkmnpqrstuvwxyz023456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 8; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return pass;
        }
    }
}
