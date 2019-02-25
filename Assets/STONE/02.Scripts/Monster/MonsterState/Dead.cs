using UnityEngine;

namespace TMI
{
    public class Dead : State
    {
        private DeadEffecter deadEffecter;

        private void Awake()
        {
            deadEffecter = GetComponent<DeadEffecter>();
            deadEffecter.CompleteEffect += Exit;
        }

        public override void Enter()
        {
            Debug.Log("난 죽었다");

            //if (TMI.StoneBase.type == TMI.StoneBase.StoneType.Dimement)
            StartCoroutine(deadEffecter.DimementEffect());
            //else
            //{
            //    StartCoroutine(TMI.GameEffectManager.Instance.LaserEffect(transform));
            //    Debug.Log("디멘터를 못찾았음");
            //}
        }

        public override void Exit()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }
    }
}