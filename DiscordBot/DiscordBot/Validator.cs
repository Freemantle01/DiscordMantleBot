namespace DiscordBot
{
    public static class Validator
    {
        public static bool IsInRange(byte value, byte min, byte max)
        {
            if(value>=min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
