using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerAction: MonoBehaviour
    {
        private WeaponSelection weaponSelection;
     

        void Start()
        {
            weaponSelection = GetComponentInParent<WeaponSelection>();
        }

        void Update ()
        {
            if (weaponSelection.selectedWeapon.IsFull())
            {
                // no reload necessary if is full
                return;
            }


            if(Input.GetButton ("Reload"))
            {
                Reload();
            }
        }

        void Reload()
        {
            weaponSelection.selectedWeapon.Reload();
        }
    
    }
}
