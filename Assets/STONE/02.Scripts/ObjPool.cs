using System.Collections;
using System.Collections.Generic;
using System;

namespace TMI
{
    public class ObjPool<T>
    {
        private int allocateCountPerOnce;
        private Func<T> CreateFuntion;

        private Stack<T> objects;

        /// <summary>
        /// 생성한오브젝트들이 들어있는 스택
        /// </summary>
        /// <param name="allocateCountPerOnce"></param>
        /// <param name="CreateFuntion"></param>
        public ObjPool(int allocateCountPerOnce, Func<T> CreateFuntion)
        {
            this.allocateCountPerOnce = allocateCountPerOnce;
            this.CreateFuntion = CreateFuntion;

            this.objects = new Stack<T>(this.allocateCountPerOnce);

            Allocate();
        }

        private void Allocate()
        {
            for (int i = 0; i < allocateCountPerOnce; ++i)
                objects.Push(CreateFuntion());
        }

        public T Pop()
        {
            // 스택에 오브젝트가 없으면, 새로 할당
            if (this.objects.Count <= 0)
                Allocate();

            return objects.Pop();
        }

        public void Push(T obj)
        {
            
            objects.Push(obj);
        }
    }
}