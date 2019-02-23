using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Mob_Base : State
    {
        protected Monster monster;

        public State_Mob_Base(GameObject owner) : base(owner)
        {
            Initialize(owner);
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);
            monster = owner.gameObject.GetComponent<Monster>();
        }
    }
}