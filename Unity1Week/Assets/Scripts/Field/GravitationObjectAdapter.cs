using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gravity;

public class GravitationObjectAdapter : MonoBehaviour
{
    [SerializeField] GameObject gravityObject;
    private void Awake()
    {
        GravityManager.SetGravityObject(gravityObject);
    }
}
