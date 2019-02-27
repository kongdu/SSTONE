using System;
using System.Collections;
using UnityEngine;

namespace TMI
{
    public class Player : Singleton<Player>
    {
        public enum State { Idle, Live, Die }

        public State state = State.Live;

        public event Action DieBegin = () => { };

        public bool IsDied { get => hp <= 0; }
        public bool IsLive { get => hp >= 0; }

        private int maxhp { get; set; }

        private int hp;

        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (IsLive)
                    hp = value;
                UIManager.Instance.hpBar.ShowHpBar(hp / (float)maxhp);
            }
        }

        private void Awake()
        {
            PlayerInfoReset();
        }

        public void PlayerInfoReset()
        {
            maxhp = 5;
            Hp = maxhp;
        }

        public int Hittable()
        {
            return Hp -= 1;
        }

        private void Update()
        {
            if (IsDied)
            {
                DieBegin?.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            var hit = other.transform.GetComponent<Hittable>();
            if (hit == null)
                return;

            if (IsDied)
            {
                DieBegin?.Invoke();
            }
            else
            {
                hit.OnHit();
                Hittable();
            }
        }
    }
}