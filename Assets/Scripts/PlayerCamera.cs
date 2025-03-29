using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    public float rotationX;
    public float rotationY;

    public GameObject player;
    public float offSetX = 0f;
    public float offSetY = 0f;
    public float offSetZ = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        print("Welcome to the Space Puzzle prototype in it's... current state. Controls: E - Used to interact with the coloured cubes. Deliver those cubes to the purple table to 'score' points.");
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + offSetX, player.transform.position.y + offSetY, player.transform.position.z + offSetZ);

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotationY += mouseX;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);

        if(Input.GetKeyDown("e"))
        {
            Interact();
        }

       
    }

    public void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Food food = hit.transform.GetComponent<Food>();
            if (food != null)
            {
                food.Pickup();
            }
        }
    }
}
