using UnityEngine;

namespace TMI
{
    public class Weapon : MonoBehaviour
    {
        private enum WeaponState { IDLE, LOAD, ATTACK }

        [SerializeField]
        private WeaponState state = WeaponState.IDLE;

        //대기상태
        public void SlingIdlestate() => state = WeaponState.IDLE;

        //장전상태
        public void SlingLoadstate() => state = WeaponState.LOAD;

        //공격상태
        public void SlingAtkstate() => state = WeaponState.ATTACK;
    }
}