using UnityEngine.UI;

namespace TMI
{
    public class UIManager : Singleton<UIManager>
    {
        public Text PlayerHpText = null;

        public StoneBase[] stones;
    }
}