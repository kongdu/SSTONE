using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class testGameEnd : MonoBehaviour
    {
        public GameManager gm;
        public Monster monster;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                gm.ChangeState(GameState.Running);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gm.ChangeState(GameState.End);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                monster.GetComponent<Hittable>().OnHit();
            }
        }
    }
}