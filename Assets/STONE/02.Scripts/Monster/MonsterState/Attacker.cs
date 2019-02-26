using System.Collections;
using UnityEngine;
using System;

namespace TMI
{
    public class Attacker : MonoBehaviour
    {
        public float flySpd;

        public event Action AttackEnd = () => { };

        #region 포물선운동

        //이동할 벡터의 xyz
        private float tx;

        private float ty;
        private float tz;

        //속도. 시작인가?
        //private float v;

        //중력가속도.
        public float g = 19.8f;

        private float elapsed_time;
        public float max_height;

        //private float t;
        private Vector3 start_pos;

        private Vector3 end_pos;
        private float dat;  //도착점 도달 시간
        public Vector3 tpos;

        #endregion 포물선운동

        public Vector3 arrivepos = new Vector3(0, 0, 0);

        private void OnEnable()
        {
            arrivepos = Player.Instance.transform.position;
            start_pos = transform.position;
            end_pos = arrivepos;
            FlyToTarget(start_pos, end_pos, g, max_height);
        }

        private void FlyToTarget(Vector3 startPos, Vector3 endPos, float g, float max_height)
        //포물선 비행. 날아가며 타겟마크 알파 높이기. 적중 시 ReachedTarget실행.
        {
            start_pos = startPos;

            end_pos = endPos;

            this.g = g;

            this.max_height = max_height;

            var dh = endPos.y - startPos.y;

            var mh = max_height - startPos.y;
            //에너지 보존법칙? 1/2mv^2=mgh. m을 양쪽에서 빼면 ty=2*g*h의 루트=v가 가능하다.
            ty = Mathf.Sqrt(2 * this.g * mh);

            //a==g
            float a = this.g;
            //b== -2 * ty(위에서 구한 속도?) 왜 -2를 곱하는지?
            float b = -2 * ty;
            //c== endpos가 startpos보다 얼마나 높은가 * 2
            float c = 2 * dh;

            //거=시*속, 시=거/속=?? 근의공식인가? 예상되는 체공시간?
            dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);

            //최종적 x속도?
            tx = -(startPos.x - endPos.x) / dat;
            //최종적 y속도?
            tz = -(startPos.z - endPos.z) / dat;

            this.elapsed_time = 0;
            StartCoroutine(PositionChange());
        }

        private IEnumerator PositionChange()
        {
            while (true)
            {
                elapsed_time += Time.deltaTime * flySpd;

                //매프레임당 이동벡터의 x
                var tx = start_pos.x + this.tx * elapsed_time;
                //매프레임당 이동벡터의 y. x, z와 달리 중력에 따른 값을 빼준다. 가속도는 m/s^2이므로 위치는 가속도에 시간을 두번 곱해주면 거리를 구할 수 있음.
                var ty = start_pos.y + this.ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
                //매프레임당 이동벡터의 z
                var tz = start_pos.z + this.tz * elapsed_time;

                tpos = new Vector3(tx, ty, tz);

                //비행동안 날아가는 총알의 위치와 로테이션 변환.
                //transform.LookAt(tpos);
                transform.position = tpos;

                //_skills.targetMarkColor = new Color(0f, elapsed_time / dat, 0f, 1f);

                //총 체공시간 계산치보다 비행시간이 길다면 탈출.
                if (elapsed_time >= dat)
                {
                    AttackEnd();
                    yield break;
                }

                yield return null;
            }
        }
    }
}