using System;
using System.Text;

namespace Robot.Modules
{
    static public class  Sanatize
    {
        public static ulong SanitizeEmote(this string emoteName)
        {
            var sb = new StringBuilder();
            foreach (var @char in emoteName)
            {
                if (char.IsDigit(@char))
                {
                    sb.Append(@char);
                }
            }
            if (!ulong.TryParse(sb.ToString(), out var id))
            {
                throw new Exception("die");
            }
     
            return id;
        }
    }
}