using UnityEngine;

namespace TMI
{
    public class Base<T> where T : MonoBehaviour
    {
        public T StoneFindObj()
        {
            var go = Object.FindObjectOfType<T>();
            return go;
        }
    }
}