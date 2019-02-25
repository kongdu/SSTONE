using UnityEngine;

namespace TMI
{
    public class test : MonoBehaviour
    {
        private GameManager MGR;
        private Weapon weapon;

        // Start is called before the first frame update
        private void Start()
        {
            MGR = FindObjectOfType<GameManager>();
            weapon = FindObjectOfType<Weapon>();
        }

        // Update is called once per frame
        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //    MGR.ChangeState(GameProgressState.Waiting);
            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //    MGR.ChangeState(GameProgressState.Running);
            //if (Input.GetKeyDown(KeyCode.Alpha3))
            //    MGR.ChangeState(GameProgressState.End);
            if (Input.GetKeyDown(KeyCode.P))
                GameManager.Instance.GameOver();

            if (Input.GetKeyDown(KeyCode.Space))
                GameManager.Instance.gameStartEnd?.Invoke();
        }
    }
}