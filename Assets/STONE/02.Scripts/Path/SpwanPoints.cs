using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    // 모든 스폰포인트를 가지고 있는 데이터베이스 입니다.
    public class SpwanPoints : Singleton<SpwanPoints>
    {
        [SerializeField]
        public List<PathGenerator> spwanPoints;
    }
}