using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector2 defaultInitialPositionOnPlane = new Vector2(-4, 4);

    public float moveSpeed = 5F;
    public Vector3 jumpForce;

    private Rigidbody rb;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        /*transform.position = new Vector3(Random.Range(defaultInitialPositionOnPlane.x,
            defaultInitialPositionOnPlane.y), 0, Random.Range(defaultInitialPositionOnPlane.x,
            defaultInitialPositionOnPlane.y));*/

        rb = this.GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        transform.position += updateMove();
    }

    Vector3 updateMove()
    {
        Vector3 changePos = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            changePos += new Vector3(-transform.right.x, 0, -transform.right.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            changePos += new Vector3(transform.right.x, 0, transform.right.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            changePos += new Vector3(transform.forward.x, 0, transform.forward.z) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            changePos += new Vector3(-transform.forward.x, 0, -transform.forward.z) * Time.deltaTime * moveSpeed;
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y <= 0.1 && rb.velocity.y >= -0.1)
            {
                rb.velocity = jumpForce;
            }
        }*/
        var p = GameObject.FindGameObjectWithTag("MainCamera");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, p.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Debug.Log(p.transform.rotation);

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bul = Instantiate(bullet, transform.position, Quaternion.identity);
            bul.transform.rotation = transform.rotation;
        }*/

        return changePos;
    }
}
