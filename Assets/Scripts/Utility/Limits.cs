
namespace Utility
{
    public static class Limits
    {
        /**
     * Goal here is to loop around so we aren't doing math against huge numbers.
     */
        public static float Constrain(float input, float max, float min)
        {
            float result = input;
            if (input > max)
            {
                result -= max; // 380 - 360 = 20
            }

            if (input < min)
            {
                result += max; // -20 + 360 = 340
            }

            return result;
        }
    
        public static int Constrain(int input, int max, int min)
        {
            int result = input;
            if (input > max)
            {
                result -= max; // 17 - 16 = 1
            }

            if (input < min)
            {
                result += max; // -1 + 16 = 15
            }

            return result;
        }
    }
}
