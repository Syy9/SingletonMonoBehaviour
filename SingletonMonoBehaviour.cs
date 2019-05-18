using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Syy.Logics
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        protected static T _i;
        public static T I
        {
            get
            {
                if (_i == null)
                {
                    var type = typeof(T);
                    var gameObject = new GameObject(type.Name + "(DontSave)");
                    gameObject.AddComponent(type);
                    gameObject.hideFlags = HideFlags.DontSave;
                    GameObject.DontDestroyOnLoad(gameObject);
                }
                return _i;
            }
        }

        protected virtual void Awake()
        {
            if (_i == null)
            {
                _i = (T)this;
            }
            else if (_i != this)
            {
                GameObject.Destroy(this);
            }
        }
    }
}
