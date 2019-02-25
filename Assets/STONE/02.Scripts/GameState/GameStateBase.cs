namespace TMI
{
    public class GameStateBase
    {
        protected GameManager gmr;

        public GameStateBase(GameManager gmr)
        {
            this.gmr = gmr;
        }

        public virtual void Enter()
        { }

        public virtual void Exit()
        { }
    }
}