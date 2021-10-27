using System.Security.Cryptography;
using System.Text;

namespace autenticacao_jwt.Util
{
    public class Utils
    {
        public static string GerarMd5(string value)
        {
            MD5 md5 = MD5.Create();
            byte[] valorCriptografado = md5.ComputeHash(Encoding.Default.GetBytes(value));

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                result.Append(valorCriptografado[i].ToString("x2"));
            }

            return result.ToString();
        }
    }
}