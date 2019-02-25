using UnityEngine;

namespace TMI
{
    public class Dead : State
    {
        private void Awake()
        {
            GameEffectManager.Instance.CompleteEffect += Exit;
        }

        public override void Enter()
        {
            Debug.Log("난 죽었다");

            if (TMI.StoneBase.type == TMI.StoneBase.StoneType.Dimement)
                StartCoroutine(TMI.GameEffectManager.Instance.DimementEffect(transform));
            else
            {
                StartCoroutine(TMI.GameEffectManager.Instance.LaserEffect(transform));
                Debug.Log("디멘터를 못찾았음");
            }
        }

        public override void Exit()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }
    }
}