namespace Gun
{
    public class Ammunition
    {
        public int max;
        public int current;

        public Ammunition()
        {
            max = 10;
            current = max;
        }

        public void Decrease()
        {
            if (current >= 0)
            {
                current--;
            }
        }

        public bool IsEmpty()
        {
            return current == 0;
        }

        public void Reload()
        {
            current = max;
        }
    }
}