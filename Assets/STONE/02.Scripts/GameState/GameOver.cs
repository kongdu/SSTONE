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
            var Ms = gmr.GetComponent<ObjPoolManager>();
            var As = gmr.GetComponent<AudioSource>();
            Ms.monsters.gameObject.SetActive(false);
            As.Stop();

            Debug.Log("게임종료방");
            // 델리게이트 체인을 보여줘야한다면 여기서 보여줘도 될거같다.
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