using System;

namespace AlexandreApps.Meeting_Room.Core.Utils
{
    public static class EncriptionHelper
    {
        public static byte[] EncriptPassword(string inputString, DateTime creationDate)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(string.Concat(inputString, creationDate.Ticks));
            return new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        }
    }
}
