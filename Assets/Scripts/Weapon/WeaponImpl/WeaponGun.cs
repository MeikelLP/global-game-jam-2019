namespace Weapon.WeaponImpl
{
    public class WeaponGun : Weapon
    {

        public WeaponGun()
        {
            ammunition = new Ammunition(10, 10);
        }
    }
}