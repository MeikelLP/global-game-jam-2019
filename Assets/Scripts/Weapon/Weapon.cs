using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    [RequireComponent(typeof(WeaponSelection))]
    public class Weapon : MonoBehaviour
    {
        public Ammunition ammunition;

        //protected Damage damage;
        //protected Accuracy accuracy;
        //protected Reload; reloadTime; jamProbability
        // TODO sonstiges

        private WeaponSelection weaponSelection;
        [SerializeField] private int startAmmo = 10;
        [SerializeField] private float reloadTime = 2;
        public bool IsReloading { get; private set; }
        

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


        void Start()
        {
            ammunition = new Ammunition(startAmmo, startAmmo);
            weaponSelection = GetComponent<WeaponSelection>();
            weaponSelection.reloadIndicator.fillAmount = 0;
            weaponSelection.UpdateAmmunitionUi();
        }

        void Update()
        {
            if (weaponSelection.selectedWeapon.IsFull())
            {
                // no reload necessary if is full
                return;
            }


            if (Input.GetButton("Reload") && !IsReloading)
            {
                IsReloading = true;
                StartCoroutine(WaitForReload());
            }
        }

        private IEnumerator WaitForReload()
        {
            var time = reloadTime;
            while (time > 0)
            {
                time -= Time.deltaTime;
                weaponSelection.reloadIndicator.fillAmount = 1 - time / reloadTime; // increase instead of decrease
                yield return new WaitForEndOfFrame();
            }

            weaponSelection.selectedWeapon.Reload();
            weaponSelection.reloadIndicator.fillAmount = 0;
            weaponSelection.UpdateAmmunitionUi();
            IsReloading = false;
        }
    }
}