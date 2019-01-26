using Gun;
using UnityEngine;

namespace Player
{
    public class PlayerAction: MonoBehaviour
    {
        private GunStatus gunStatus;

        void Start()
        {
            gunStatus = GunStatus.GetInstance();
        }

        void Update ()
        {
            //timer += Time.deltaTime;

            if(Input.GetButton ("Reload"))
            {
                Reload();
            }
        }

        void Reload()
        {
            gunStatus.ammunition.Reload();
        }
    
    }
}
