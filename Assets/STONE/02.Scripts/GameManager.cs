using System;

namespace TMI
{
    public enum GameState
    {
        Waiting,
        Running,
        End
    }

    public class GameManager : Singleton<GameManager>
    {
        public GameState state = GameState.Waiting;

        public event Action ResetInfo = () => { };

        [NonSerialized]
        public Player player;

        private GameManager gameMgr = null;

        private GameStateBase statebase = null;

        public Action gameStartEnd = () => { };

        private void Awake()
        {
            gameMgr = this;
            player = FindObjectOfType<Player>();
            ChangeState(GameState.Waiting);
        }

        // 투사체로 UI를 쏘면 state를 실행중으로 변환한다.
        public void GameStart()
        {
            ChangeState(GameState.Running);
        }

        public void GameOver()
        {
            ChangeState(GameState.End);
        }

        public void ChangeState(GameState nextState)
        {
            ResetInfo?.Invoke();

            if (statebase != null)
                statebase.Exit();

            statebase = CreateStateInstance(nextState);

            statebase.Enter();
        }

        private GameStateBase CreateStateInstance(GameState nextState)
        {
            switch (nextState)
            {
                case GameState.Waiting: return new GameWaiting(gameMgr);
                case GameState.Running: return new GameStarting(gameMgr);
                case GameState.End: return new GameOver(gameMgr);
            }

            return null;
        }
    }
}