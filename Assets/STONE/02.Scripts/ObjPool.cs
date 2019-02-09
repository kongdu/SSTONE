using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class ObjPool<T> where T : class
    {
        private int count;

        public delegate T Func();

        // 호출할떄 받은 생성함수
        private Func createFuntion;

        private Stack<T> objects;

        public ObjPool(int count, Func fn)

        {
            this.count = count;

            this.createFuntion = fn;

            this.objects = new Stack<T>(this.count);

            allocate();
        }

        private void allocate()

        {
            for (int i = 0; i < this.count; ++i)

            {
                //할당이야
                //스택안에푸시한다.(함수리턴값 푸시)

                this.objects.Push(this.createFuntion());
            }
        }

        //팝
        public T pop()

        {
            //스택안의 카운트가 0이하라면
            if (this.objects.Count <= 0)

            {
                //할당();
                allocate();
            }
            //0 이상이면 스택에서팝한결과를 리턴
            return this.objects.Pop();
        }

        public void push(T obj)

        {
            //매개변수로 받은 오브젝트 스택안에 푸시
            this.objects.Push(obj);
        }
    }
}