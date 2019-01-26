namespace Weapon
{
    public class Ammunition
    {
        public int max { get; }
        public int current { get; set; }
        
        // TODO clipMax
        // TODO overallMax

        public Ammunition(int max, int current)
        {
            this.max = max;
            this.current = current;
        }
    }
}