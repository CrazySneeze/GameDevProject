using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 1, 0);
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    private RaycastHit hit;

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.rotation * Vector3.forward);

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

                    if (item.Tags.Contains("Weapon"))
                    {
                        p.GetComponent<PlayerManager>().player.addWeapon(new Weapon(item.ID, item.name, item.Description, item.Tags, int.Parse(item.Tags[1]), item.Tags[2]), item.Count);
                    }
                    else
                    {
                        p.GetComponent<PlayerManager>().player.addItem(item.item, item.Count);
                    }

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
    }
}
