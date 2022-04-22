using UnityEngine;

namespace IronBelly.Utils 
{ 
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

        #region Protected
        protected static T _instance;
        protected static object _lock = new object();
        #endregion

        #region Static
        public static T Instance {
            get {
                lock (_lock) {
                    if(!_instance)
                        _instance = (T)FindObjectOfType(typeof(T));

                    return _instance;
                }
            }
        }
        #endregion

        #region Quit
        private static bool applicationIsQuitting = false;
	    public void OnDestroy () {
		    applicationIsQuitting = true;
	    }
        #endregion

    }

}