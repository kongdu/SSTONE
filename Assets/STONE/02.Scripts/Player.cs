using UnityEngine;

namespace TMI
{
    public class Player : MonoBehaviour
    {
        private int PlayerMaxHp { get; set; }

        private int playerHp;

        private int PlayerHp
        {
            set
            {
                playerHp = value;
                UIManager.instance.PlayerHpText.text = playerHp.ToString();
            }
        }

        public bool IsDied
        {
            // get => playerHp <= 0;
            get
            {
                return playerHp <= 0;
            }
        }

        private void Awake()
        {
            GameManager.instance.Initialize += ResetInfo;
        }

        public void ResetInfo()
        {
            PlayerMaxHp = 10; //예비수치 10
            PlayerHp = PlayerMaxHp;
        }

        //증감
        /// <summary>
        /// 체력회복하는 돌에서 사용시 수정예정.
        /// </summary>
        public void HpIncrease(int hp) =>
            PlayerHp = playerHp + hp;

        //감소
        private void HpDecrease(int hp) =>
            PlayerHp = playerHp - hp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("몬스터에 달린 태그"))
            {
                if (IsDied)
                {
                    // 플레이어가 죽었을때 GameManager에 알려줌.
                }
                else
                {
                    // Hpincrease(Hp감소수치)
                }
            }
        }
    }
}