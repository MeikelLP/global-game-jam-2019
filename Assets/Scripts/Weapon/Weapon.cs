namespace Weapon
{
    public class Weapon
    {
        protected Ammunition ammunition;
        //protected Damage damage;
        //protected Accuracy accuracy;
        //protected Reload; reloadTime; jamProbability
        // TODO sonstiges
       
        public void Reload()
        {
            // TODO applyReloadTime
            ammunition.current = ammunition.max;
        }

        public bool IsFull()
        {
            return ammunition.current == ammunition.max;
        }
        
        public bool IsEmpty()
        {
            return ammunition.current == 0;
        }
        
        public void DecreaseAmmunition()
        {
            if (ammunition.current >= 0)
            {
                ammunition.current--;
            }
        }
    }
}