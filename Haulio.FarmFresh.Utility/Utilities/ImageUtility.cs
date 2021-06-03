using System;
using System.IO;

namespace Haulio.FarmFresh.Utility
{
    public static class ImageUtility
    {
        public static bool SaveBase64(string filePath, string Base64ImageString)
        {
            try
            {
                File.WriteAllBytes(filePath, Convert.FromBase64String(Base64ImageString));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
