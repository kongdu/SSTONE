using UnityEngine;

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
            Debug.Log("게임종료방");
            // 업적? 을 보여줘야한다면 여기서 보여줘도 될거같다.
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