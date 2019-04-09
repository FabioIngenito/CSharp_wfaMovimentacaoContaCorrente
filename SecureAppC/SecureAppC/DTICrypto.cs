using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SecureAppC
{
    public class DTICrypto
    {
        public string Cifrar(string vstrTextToBeEncrypted, string vstrEncryptedKey)
        {
            byte[] bytValue = null;
            byte[] bytKey = null;
            byte[] bytEncoded = { 0 };
            byte[] bytIV = { 122, 10, 15, 77, 131, 71, 21, 59, 255, 81, 5, 7, 14, 209, 24, 111 };
            int intLeght = 0;
            int intRemaining = 0;
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = null;
            RijndaelManaged objRijndaelManaged = null;

            //Retira os caracteres nulos da palavra a ser cifrada
            vstrTextToBeEncrypted = TiraCaracteresNulos(vstrTextToBeEncrypted);

            //Cada valor deve assistir na tabela ASCII
            bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray());

            intLeght = Strings.Len(vstrEncryptedKey);

            //A chave gerada será de 256 nits long (32 bytes)
            //Se for maior que 32 bytes, então vamos truncar;
            //Se for menor que 32 bytes, vamos alocar para atingir 256 bits.

            if (intLeght >= 32)
            {
                vstrEncryptedKey = Strings.Left(vstrEncryptedKey, 32);
            }
            else
            {
                intLeght = Strings.Len(vstrEncryptedKey);
                intRemaining = 32 - intLeght;
                vstrEncryptedKey = vstrEncryptedKey + Strings.StrDup(intRemaining, "X");
            }

            bytKey = Encoding.ASCII.GetBytes(vstrEncryptedKey.ToCharArray());

            //Para quem quiser pesquisar sobre o algoritmo que estamos usando:
            //O nome dele é Rijndael
            //Foi criado por Vicent Rijdament e Joan Daemen.

            objRijndaelManaged = new RijndaelManaged();

            //Cria o valor a ser cifrado e escreve a conversão em bytes
            try
            {
                objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
                objCryptoStream.Write(bytValue, 0, bytValue.Length);

                objCryptoStream.FlushFinalBlock();

                bytEncoded = objMemoryStream.ToArray();
                objMemoryStream.Close();
                objCryptoStream.Close();
            }
            catch
            {
            }

            //Retorna o valor cifrado
            //(realizando conversão de byte para base64)
            return Convert.ToBase64String(bytEncoded);

        }

        public string Decifrar(string vstrStringToBeDecrypted, string vstrDecryptionKey)
        {
            byte[] bytDataToBeDecrypted = null;
            byte[] bytTemp = null;
            byte[] bytIV = { 122, 10, 15, 77, 131, 71, 21, 59, 255, 81, 5, 7, 14, 209, 24, 111 };
            RijndaelManaged objRijndaelManaged = new RijndaelManaged();
            MemoryStream objMemoryStream = null;
            CryptoStream objCryptoStream = null;
            byte[] bytDecryptionKey = null;
            int intLenght = 0;
            int intRemainig = 0;
            //Dim intCtr As Integer
            string strReturnString = string.Empty;
            //Dim achrCharacterArray() As Char
            //Dim intIndex As Integer

            //Converte de base64 cifrada para array de bytes
            bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted);

            //A chave gerada será de 256 bits long (32 bytes)
            //Se for maior que 32 bytes, então vamos truncar;
            //Se for menor que 32 bytes, vamos alocar para atingir 256 bits.
            intLenght = Strings.Len(vstrDecryptionKey);

            if (intLenght >= 32)
            {
                vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32);
            }
            else
            {
                intLenght = Strings.Len(vstrDecryptionKey);
                intRemainig = 32 - intLenght;
                vstrDecryptionKey = vstrDecryptionKey + Strings.StrDup(intRemainig, "X");
            }

            bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray());

            bytTemp = new byte[bytDataToBeDecrypted.Length + 1];

            objMemoryStream = new MemoryStream(bytDataToBeDecrypted);

            //Escreve o valor descriptografado após a cnversão

            try
            {
                objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), CryptoStreamMode.Read);
                objCryptoStream.Read(bytTemp, 0, bytTemp.Length);

                objCryptoStream.FlushFinalBlock();
                objMemoryStream.Close();
                objCryptoStream.Close();
            }
            catch
            {
            }

            //Retorna o valor descriptografado
            return TiraCaracteresNulos(Encoding.ASCII.GetString(bytTemp));
        }

        private string TiraCaracteresNulos(string vstrStringWithNulls)
        {
            int intPosition = 0;
            string strStringWithOutNulls = null;

            intPosition = 1;
            strStringWithOutNulls = vstrStringWithNulls;

            while (intPosition > 0)
            {
                intPosition = Strings.InStr(intPosition, vstrStringWithNulls, Constants.vbNullChar);

                if (intPosition > 0)
                {
                    strStringWithOutNulls = Strings.Left(strStringWithOutNulls, intPosition - 1) + Strings.Right(strStringWithOutNulls, Strings.Len(strStringWithOutNulls) - intPosition);
                }

                if (intPosition > strStringWithOutNulls.Length)
                {
                    break; // TODO: might not be correct. Was : Exit Do
                }
            }

            return strStringWithOutNulls;
        }
    }
}
