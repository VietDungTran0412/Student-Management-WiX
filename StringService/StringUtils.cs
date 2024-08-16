using System;

namespace StringService
{
    public class StringUtils
    {
        public static Boolean IsSubString(String source, String target)
        {
            int length1 = source.Length;
            int length2 = target.Length;
            // Iterate through S2
            for (int i = 0; i <= length2 - length1; i++)
            {

                // Check for substring match
                int j;
                for (j = 0; j < length1; j++)
                {

                    // Mismatch found
                    if (target[i + j] != source[j])
                    {
                        break;
                    }
                }

                // If we completed the inner loop, we found a match
                if (j == length1)
                {
                    // Return starting index
                    return true;
                }
            }
            // No match found
            return false;
        }
    }
}
