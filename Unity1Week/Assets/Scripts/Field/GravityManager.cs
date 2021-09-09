using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gravity
{
    public class GravityManager : MonoBehaviour
    {
        public static float gravity = 9.8f;
        static GameObject gravityObject;
        static Transform gravityObjectTrans;
        public static void SetGravityObject(GameObject gameObject)
        {
            gravityObject = gameObject;
            gravityObjectTrans = gameObject.transform;
        }
        public static Vector3 GravityVector(Transform transform)
        {
            Vector3 vec =  gravityObjectTrans.position- transform.position ;
            vec = vec.normalized;
            return vec * gravity;
        }
    }
}
