using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashToByte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string l_filePath;

            if (args.Length > 0)
            {
                l_filePath = args[0];
            }
            else
            {
                Console.WriteLine("Por favor, digite o caminho do arquivo:");
                l_filePath = Console.ReadLine();
                Log.Logger.Debug("Program", "Main", "Arquivo armazenado na váriavael");
            }

            try
            {
                if (!File.Exists(l_filePath))
                {

                    Console.WriteLine("Não foi possível localizar o arquivo");
                    Log.Logger.Error("Program", "Main", "File not found: 400");
                    return;
                }

                byte[] l_sizeBytes = File.ReadAllBytes(l_filePath);

                using (MD5 l_md5 = MD5.Create())
                {
                    byte[] l_hashBytes = l_md5.ComputeHash(l_sizeBytes);

                    Console.WriteLine($"O tamanho do arquivo é: {l_sizeBytes.Length} bytes.");
                    Log.Logger.Debug("Program", "Main", "Arquivo estimado com sucesso");

                    StringBuilder l_hashStringBuilder = new StringBuilder();
                    for (int i = 0; i < l_hashBytes.Length; i++)
                    {
                        l_hashStringBuilder.Append(l_hashBytes[i].ToString("x2"));
                    }

                    string l_hashString = l_hashStringBuilder.ToString();

                    Console.WriteLine($"O Hash MD5 do arquivo é: {l_hashString}");
                    Log.Logger.Debug("Program", "Main", "Hash criada com sucesso");

                }
            }
            catch (Exception l_ex)
            {
                Console.WriteLine($"Erro ao tentar abrir o arquivo: {l_ex.Message}");
                Log.Logger.Error("Program", "Main", "Erro ao abrir o arquivo");
            }

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }

    }
}