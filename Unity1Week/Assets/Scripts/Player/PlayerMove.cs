using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gravity;
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    [SerializeField] InputProvider inputProvider;
    [SerializeField] float maxSpeed = 5.0f;
    [SerializeField] float rotateSpeed = 0.01f;
    [SerializeField] float acceralat = 1.0f;
    [SerializeField] float speed = 0;
    [SerializeField] float attenuation = 0.1f;
    [SerializeField] float jumpPower = 5.0f;

    private Ray ray;
    private float distance = 0.5f;
    private RaycastHit hit; 
    private Vector3 rayPosition;
    [SerializeField] float rayUnder = 0.5f;
    [SerializeField] bool isGround;
    [SerializeField]Vector3 moveVector=new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        rayPosition = tr.position + tr.up * -1*rayUnder; 
        ray = new Ray(rayPosition, transform.up * -1); 
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        if (Physics.Raycast(ray, out hit, distance)) // レイが当たった時の処理
        {
            if (hit.collider.tag == "Ground") // レイが地面に触れたら、
            {
                isGround = true; // 地面に触れたことにする

            }
            else // そうでなければ、
            {
                isGround = false; // 地面に触れてないことにする

            }
        }
        else
        {
            isGround = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 inputVector=new Vector2(0,0);
        if (speed > 0) speed -= speed * attenuation;
        else speed = 0;
        if (inputProvider.IsDownButton())
        {
            inputVector.y += -1;
        }
        if (inputProvider.IsUpButton())
        {
            inputVector.y += -1;
        }
        if (inputProvider.IsLeftButton())
        {
            inputVector.x -= 1;
        }
        if (inputProvider.IsRightButton())
        {
            inputVector.x += 1;
        }
        moveVector += inputVector.x*tr.forward+inputVector.y*tr.right;
        if (moveVector!=Vector3.zero) moveVector /= moveVector.magnitude;
        if (inputVector != Vector2.zero) speed += acceralat;
        if (speed > maxSpeed) speed = maxSpeed;
        moveVector *= speed;

        if (inputVector.x != 0)
        {
            Vector3 up = tr.up;
            Vector3 rot= Vector3.RotateTowards(new Vector3(0, 1, 0), up, rotateSpeed, rotateSpeed);
            tr.Rotate(rot*inputVector.x);
        }
        moveVector = moveVector.magnitude * tr.forward;

        if (isGround && inputProvider.IsJumpButtonDown())
        {
            moveVector += tr.up * jumpPower;
        }
        rb.AddForce(moveVector);
    }
}
