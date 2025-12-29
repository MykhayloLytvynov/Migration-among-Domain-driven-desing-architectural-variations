using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Infrastructure.Utility
{
    /// <summary>
    /// The file helper.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Reads bytes from file.
        /// </summary>
        /// <param name="fileName">
        /// The c file name.
        /// </param>
        /// <returns>
        /// Byte array <see cref="byte[]"/>.
        /// </returns>
        public static byte[] ReadBytesFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {

                BinaryReader r = new BinaryReader(fs);
                int lg = Convert.ToInt32(fs.Length);
                byte[] bytes = new byte[lg + 7];
                int i = 0;
                for (i = 0; i < fs.Length; i++)
                {
                    bytes[i] = (byte)fs.ReadByte();
                }

                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// The save data.
        /// </summary>
        /// <param name="byteArray">
        /// The byte array.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int SaveBytesToFile(byte[] byteArray, string fileName)
        {
            if (byteArray != null)
            {
                int length = byteArray.Length;

                FileStream oFileStream = new FileStream(fileName, FileMode.Create);
                BinaryWriter binWriter = new BinaryWriter(oFileStream);

                for (int i = 0; i < length; i++)
                {
                    binWriter.Write(byteArray[i]);
                }

                binWriter.Flush();
                binWriter.Close();
                binWriter = null;
                oFileStream.Close();
                oFileStream = null;
            }

            return 1;
        }

        /// <summary>
        /// The read directory.
        /// </summary>
        /// <param name="directoryName">
        /// The directory name.
        /// </param>
        /// <param name="fileMask">
        /// The file mask.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ReadDirectory(string directoryName, string fileMask)
        {
            string result = String.Empty;

            DirectoryInfo di = new DirectoryInfo(directoryName);
            List<FileInfo> files = di.GetFiles(fileMask).OrderBy(fi => fi.Name).ToList();

            foreach (FileInfo fi in files)
            {
                result += ReadFile(fi.FullName);
            }

            return result;
        }

        /// <summary>
        /// The read file.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ReadFile(string fileName)
        {
            var fileReader = new StreamReader(fileName);
            var resultStr = fileReader.ReadToEnd();
            fileReader.Close();

            return resultStr;
        }

        /// <summary>
        /// The replace in file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="searchText">
        /// The search text.
        /// </param>
        /// <param name="replaceText">
        /// The replace text.
        /// </param>
        public static void ReplaceTextInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }
    }
}
