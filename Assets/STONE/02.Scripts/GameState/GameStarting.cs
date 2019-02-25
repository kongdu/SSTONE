using UnityEngine;

namespace TMI
{
    public class GameStarting : GameStateBase
    {
        public GameStarting(GameManager gmr) : base(gmr)
        {
            gmr.player.state = Player.State.Live;
        }

        public override void Enter()
        {
            Debug.Log("게임시작");

            gmr.player.DieBegin += gmr.GameOver;
        }

        public override void Exit()
        {
            Debug.Log("게임끝");
            gmr.player.DieBegin -= gmr.GameOver;
        }
    }
}