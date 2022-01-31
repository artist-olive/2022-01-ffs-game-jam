using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private GameObject seed;
    Seed Seed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (seed == null)
                {
                    bool IsSeed = hit.transform.CompareTag("Seed");

                    if (IsSeed)
                    {
                        //check if seed was clicked
                        Debug.Log("Selected seed!");
                        seed = hit.transform.gameObject;
                        Seed = seed.GetComponent<Seed>();
                        Seed.setIsClicked(true);
                    }
                }
                else
                {
                    bool IsLevel = hit.transform.CompareTag("Level");
                    Debug.Log("Seed already selected");
                    if(IsLevel)
                    {
                        Debug.Log("Clicked land");
                        // if you click on land, destroy the seed, make a plant, and make seed and Seed null in this click manager
                        Seed.HandleDestroyAndCreateSprout(hit.point);
                        Seed = null;
                        seed = null;
                    }
                }
            }
        }
    }
}
