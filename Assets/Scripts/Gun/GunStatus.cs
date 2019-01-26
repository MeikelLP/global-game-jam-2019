namespace Gun
{
    using System.Collections;
    using System.Collections.Generic;
    using Gun;
    using UnityEngine;

    public class GunStatus
    {
        private static GunStatus instance;

        public Ammunition ammunition;
        //public Gun TODO what gun is used

        private GunStatus()
        {
            ammunition = new Ammunition();
        }

        public static GunStatus GetInstance()
        {
            return instance ?? (instance = new GunStatus());
        }
    }
}