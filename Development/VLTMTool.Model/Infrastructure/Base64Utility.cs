
namespace VLTMTool.Model.Infrastructure
{
    public class Base64Utility
    {
        #region Public Methods

        /// <summary>
        /// Codifica el texto plano pasado en el argumento
        /// </summary>
        /// <param name="plainText">Texto plano</param>
        /// <returns>Devuelve el texto codificado correspondiente a la entrada introducida</returns>
        public static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodifica el texto codificado pasado en el argumento
        /// </summary>
        /// <param name="base64EncodedData">Texo codificado</param>
        /// <returns>Devuelve el texto decodificado correspondiente a la entrada introducida</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion Public Methods
    }
}
