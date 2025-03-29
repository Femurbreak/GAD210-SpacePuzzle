using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject gameObjectBeingMoved;
    public float TimeScaler = 0.85f;
    private bool ObjectPickedUp = false;
    public Rigidbody rb;
    public GameObject FoodSpawner;
    public bool PickItUp = false;
    public bool redFood;
    public bool blueFood;
    public bool greenFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PickItUp)
        {
            Pickup();
            PickItUp=false;
        }
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

    public void ResetFood()
    {
        gameObject.transform.position = FoodSpawner.transform.position;
    }
}
