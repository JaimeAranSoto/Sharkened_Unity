using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;
    public float rotationSpeed = 58f;
    private float accel = 0f;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Fire") > 0.2f)
        {
            if (accel <= 1)
            {
                accel += 1 * Time.fixedDeltaTime;
            }
            Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
            transform.Translate(localForward * speed * accel * Time.fixedDeltaTime);
        }

        if (Input.GetButtonDown("X"))
        {
            anim.SetTrigger("Attack");
        }

        else
        {
            accel = 0;
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime, 0, Space.World);
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f)
        {


            transform.Rotate(Input.GetAxis("Vertical") * rotationSpeed * Time.fixedDeltaTime, 0, 0, Space.Self);
        }
        //transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,0,1);

    }
}
