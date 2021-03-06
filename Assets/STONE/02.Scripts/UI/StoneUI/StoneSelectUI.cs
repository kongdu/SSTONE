﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TMI
{
    /// <summary>
    /// WheelPivot 프리팹에 붙일 스크립트
    /// </summary>
    public class StoneSelectUI : MonoBehaviour
    {
        public List<GameObject> stonePrefabs;
        public List<StoneBase> stones;
        public StoneBase SelectedStone { get => stones[0]; }
        public float distance = 1f;
        public GameObject selectedCircle;
        private float angleOffset = 0f;

        private void Awake()
        {
            angleOffset = 360f / stonePrefabs.Count;
            SpawnStones();
        }

        private void Start()
        {
            selectedCircle.transform.localPosition = new Vector3(0f, distance);
        }

        private void Update()
        {
            ///// 테스트 코드
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MovePrev();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveNext();
        }

        private void OnEnable()
        {
            //ViveController.OnTouchPadSwipe +=
            ViveController.OnClickPad_LeftSide += MovePrev;
            ViveController.OnClickPad_RightSide += MoveNext;
        }

        private void OnDisable()
        {
            //ViveController.OnTouchPadSwipe -=
            ViveController.OnClickPad_LeftSide -= MovePrev;
            ViveController.OnClickPad_RightSide -= MoveNext;
        }

        /// <summary>
        /// StonePrefab을 Instantiate해서 stones리스트에 넣기
        /// </summary>
        private void SpawnStones()
        {
            foreach (var item in stonePrefabs)
            {
                GameObject stoneGO = Instantiate(item, transform.position, transform.rotation, transform);
                stones.Add(stoneGO.GetComponent<StoneBase>());
            }

            MoveTo();
            AlphaTo();
        }

        /// <summary>
        /// 기준 축(원점으로부터 y축으로 올라간 위치를 0도)
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        private static Vector3 CalcPosition(float angle, float distance)
        {
            float radian = Mathf.Deg2Rad * angle;
            return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0f) * distance;
        }

        private void LoopStone(Func<int> GetRemoveIndex, Func<int> GetInsertIndex)
        {
            var tmpStone = stones[GetRemoveIndex()];
            stones.RemoveAt(GetRemoveIndex());
            stones.Insert(GetInsertIndex(), tmpStone);
        }

        public void MoveNext()
        {
            LoopStone(() => stones.Count - 1, () => 0);
            MoveTo();
            AlphaTo();
        }

        public void MovePrev()
        {
            LoopStone(() => 0, () => stones.Count);
            MoveTo();
            AlphaTo();
        }

        private void MoveTo(float angle = 0f)
        {
            foreach (var stone in stones)
            {
                if (stone.IsShooting)
                    continue;
                stone.transform.localPosition = CalcPosition(angle, distance);
                angle += angleOffset;
            }
        }

        private void AlphaTo(float angle = 0.0f)
        {
            foreach (var stone in stones)
            {
                if (stone.IsShooting)
                    continue;

                var mat = stone.GetComponent<Renderer>().material;
                var percent = (Mathf.Abs(angle - 180.0f) / 180.0f);

                var color = mat.color;
                color.a = percent;
                mat.color = color;

                angle += angleOffset;
            }
        }
    }
}