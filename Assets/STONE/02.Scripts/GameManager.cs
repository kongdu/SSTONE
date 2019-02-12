using System;

namespace TMI
{
    public class GameManager : Singleton<GameManager>
    {
        public enum GameProgressState
        {
            GAMESTART,
            GAMEOVER
        }

        public GameProgressState state = GameProgressState.GAMEOVER;

        public Action Initialize;

        private Action Progress;

        private void Awake()
        {
            Progress += 게임시작;
        }

        /// <summary>
        /// 호출하게 되면 상태가 변함. START/OVER
        /// </summary>
        public void StateConversion()
        {
            Progress?.Invoke();

            if (state == GameProgressState.GAMESTART)
            {
                Progress -= 게임시작;
                Progress += 종료;
            }
            else
            {
                Progress -= 종료;
                Progress += 게임시작;

                // TODO : 초기화 기능

                // 게임이 끝났을때 몬스터쪽의 리셋정보 이벤트를 연결
                Initialize?.Invoke();
            }
        }

        /// <summary>
        /// 처음에 시작할떄
        /// </summary>
        public void 게임시작() => state = GameProgressState.GAMESTART;

        /// <summary>
        /// 클리어/종료조건 (플레이어가 죽음)
        /// </summary>
        public void 종료() => state = GameProgressState.GAMEOVER;
    }
}