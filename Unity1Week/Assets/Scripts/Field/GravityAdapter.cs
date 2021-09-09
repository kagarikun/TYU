using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gravity;

public class GravityAdapter : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Vector3 gravityVector=GravityManager.GravityVector(tr);
        rb.AddForce(gravityVector);
        Quaternion targetRotation = Quaternion.FromToRotation(tr.up, -gravityVector) * tr.rotation;
        tr.rotation = Quaternion.Lerp(tr.rotation, targetRotation, 120 * Time.deltaTime);
    }
}
