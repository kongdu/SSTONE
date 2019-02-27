using UnityEngine;

namespace TMI
{
    public class Dead : State
    {
        private DeadEffecter deadEffecter;

        private void Awake()
        {
            deadEffecter = GetComponent<DeadEffecter>();
            deadEffecter.CompleteEffect += EndSequence;
            enabled = false;
        }

        private void OnEnable()
        {
            deadEffecter.PlayDead();
        }

        //public override void Enter()
        //{
        //    Debug.Log("난 죽었다");

        //    //if (TMI.StoneBase.type == TMI.StoneBase.StoneType.Dimement)
        //    //StartCoroutine(deadEffecter.DimementEffect());
        //    deadEffecter.PlayDead();
        //    //else
        //    //{
        //    //    StartCoroutine(TMI.GameEffectManager.Instance.LaserEffect(transform));
        //    //    Debug.Log("디멘터를 못찾았음");
        //    //}
        //}

        public void EndSequence()
        {
            //Debug.Log("아이들로");
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Idle>());
        }

        private void OnDisable()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }

        //public override void Exit()
        //{
        //    ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        //}
    }
}