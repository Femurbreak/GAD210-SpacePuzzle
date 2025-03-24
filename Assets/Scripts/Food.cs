using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject gameObjectBeingMoved;
    public float TimeScaler = 0.85f;
    public bool ObjectPickedUp = false;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectPickedUp)
        {
            gameObject.transform.position = Vector3.Lerp(gameObjectBeingMoved.transform.position, transform.position, TimeScaler);
        }
    }

    public void Pickup()
    {
        ObjectPickedUp = true;
        rb.useGravity = false;
    }

    public void Dropped()
    {
        ObjectPickedUp = false;
        rb.useGravity = true;
    }

    public void Disabled()
    {
        gameObject.SetActive(false);
    }

    public void Enabled()
    {
        gameObject.SetActive(true);
    }
}
