using UnityEngine;

namespace TMI
{
    public class test : MonoBehaviour
    {
        private GameManager MGR;

        // Start is called before the first frame update
        private void Start()
        {
            MGR = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) MGR.StateConversion();
        }
    }
}