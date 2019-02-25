using UnityEngine;

namespace TMI
{
    public class GameWaiting : GameStateBase
    {
        public GameWaiting(GameManager gmr) : base(gmr)
        {
            gmr.player.state = Player.State.Die;
        }

        public override void Enter()
        {
            Debug.Log("대기방");
            //정보 리셋

            gmr.gameStartEnd += gmr.GameStart;
            gmr.ResetInfo += gmr.player.PlayerInfoReset;
        }

        public override void Exit()
        {
            Debug.Log("대기방 상태끝");
            gmr.gameStartEnd -= gmr.GameStart;
            gmr.ResetInfo -= gmr.player.PlayerInfoReset;
        }
    }
}