using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private bool canJump = true;
    public float moveSpeed = 5F;
    public Vector3 jumpForce;

    private Rigidbody rb;

    private RaycastHit hit;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += updateMove();

        if (Input.GetKey(KeyCode.Space))
        {
            if (canJump)
            {
                if (rb.velocity.y <= 0.1 && rb.velocity.y >= -0.1)
                {
                    //rb.velocity = jumpForce;
                    canJump = false;
                }
            }
        }
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Did Hit " + hit.transform.tag);

                if (hit.transform.tag.Equals("Item"))
                {
                    //debug to visualise ray when in editor
                    Debug.DrawRay(transform.position, ray.direction * hit.distance, Color.yellow);

                    //adds the item hit by the raycast to the players inventory
                    var p = GameObject.FindGameObjectWithTag("PlayerManager");
                    var item = hit.transform.GetComponent<ItemObject>();
                    p.GetComponent<PlayerManager>().player.addItem(item.item, item.Count);
                    Debug.Log(p.GetComponent<PlayerManager>().player.invToStr());

                    //destorys the object hit by the raycast
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, ray.direction * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        return changePos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            canJump = true;
        }
    }
}
