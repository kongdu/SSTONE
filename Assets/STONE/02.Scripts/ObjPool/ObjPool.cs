using System.Collections;
using System.Collections.Generic;
using System;

namespace TMI
{
    public class ObjPool<T>
    {
        private int allocateCountPerOnce;
        private Func<T> CreateFunction;
        private Action<T> ActiveFunction;

        private Stack<T> objects;

        /// <summary>
        /// 생성한오브젝트들이 들어있는 스택
        /// </summary>
        /// <param name="allocateCountPerOnce"></param>
        /// <param name="CreateFuntion"></param>
        public ObjPool(int allocateCountPerOnce, Func<T> CreateFuntion, Action<T> ActiveFunction = null)
        {
            this.allocateCountPerOnce = allocateCountPerOnce;
            this.CreateFunction = CreateFuntion;
            if (ActiveFunction != null)
            {
                this.ActiveFunction = ActiveFunction;
            }
            this.objects = new Stack<T>(this.allocateCountPerOnce);

            Allocate();
        }

        private void Allocate()
        {
            for (int i = 0; i < allocateCountPerOnce; ++i)
                objects.Push(CreateFunction());
        }

        public T Pop()
        {
            // 스택에 오브젝트가 없으면, 새로 할당
            if (this.objects.Count <= 0)
                Allocate();
            var obj = objects.Pop();
            ActiveFunction(obj);

            return obj;
        }

        public void Push(T obj)
        {
            ActiveFunction(obj);
            objects.Push(obj);
        }
    }
}