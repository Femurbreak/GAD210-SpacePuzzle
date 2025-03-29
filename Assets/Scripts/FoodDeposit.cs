using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDeposit : MonoBehaviour
{
    public int redCollected = 0;
    public int greenCollected = 0;
    public int blueCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Food food = other.GetComponent<Food>();
        if (food != null)
        {
            food.Dropped();
            food.ResetFood();
            if (other.GetComponent<Food>().redFood)
            {
                redCollected++;
                print("Red collected =" + redCollected);
            }
            else if (other.GetComponent<Food>().greenFood)
            {
                greenCollected++;
                print("Green collected =" + greenCollected);
            }
            else if (other.GetComponent<Food>().blueFood)
            {
                blueCollected++;
                print("Blue collected =" + blueCollected);
            }
        }
    }
}
