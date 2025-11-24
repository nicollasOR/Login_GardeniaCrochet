using System.Security.Cryptography;
using System.Text;


namespace Login.Services
{
    public static class HashServico
    {
        public static byte[] GerarHashBytes(string senha)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }
    }
}