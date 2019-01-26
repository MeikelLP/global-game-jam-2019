using System;
using UnityEngine;
using Weapon.WeaponImpl;

namespace Weapon
{
    public class WeaponSelection : MonoBehaviour
    {
        private Weapon[] weapons;
        public Weapon selectedWeapon;

        void Start()
        {
            weapons = new Weapon[3];
            weapons[0] = new WeaponGun();
            //weapons[1] = new WeaponGun();
            //weapons[2] = new WeaponGun();
            // TODO add weapons

            selectedWeapon = weapons[0];
        }
        
        
        void Update()
        {
            // TODO checkInput
            Switch();
            NextWeapon();
            PreviousWeapon();
        }
        
        public void Switch()
        {
            // TODO mouse wheel up
            // TODO mouse wheel down 
        }

        void Switch(int weaponNr)
        {
            selectedWeapon = weapons[weaponNr];
        }

        void NextWeapon()
        {
            // TODO implement   
        }
        
        void PreviousWeapon()
        {
            // TODO implement
        }
        
    }
}