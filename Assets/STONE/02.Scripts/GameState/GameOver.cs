using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TMI
{
    public class GameOver : GameStateBase
    {
        public GameOver(GameManager gmr) : base(gmr)
        {
            gmr.player.state = Player.State.Die;
        }

        public override void Enter()
        {
            var allMonsters = gmr.GetComponent<ObjPoolManager>();
            var allMonstersAudiosource = gmr.GetComponent<AudioSource>();

            StateMachine[] d = allMonsters.monsters.GetComponentsInChildren<StateMachine>();
            foreach (var i in d)
            {
                i.ChangeState(() => i.GetComponent<Dead>());
            }
            gmr.GetComponent<MonsterManager>().StopAllCoroutines();
            allMonstersAudiosource.Stop();

            Debug.Log("게임종료방");

            // 델리게이트체인을 보여줘야한다면 여기서 보여줘도 될거같다.
            gmr.gameStartEnd += gmr.GameStart;
            gmr.ResetInfo += gmr.player.PlayerInfoReset;
        }

        public override void Exit()
        {
            Debug.Log("게임종료상태끝");
            gmr.gameStartEnd -= gmr.GameStart;
            gmr.ResetInfo -= gmr.player.PlayerInfoReset;
        }
    }
}