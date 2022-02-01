using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{
    [SerializeField] GameObject[] plants;


    void Start()
    {
        StartCoroutine("HandleReplaceWithPlant");
    }

    private IEnumerator HandleReplaceWithPlant()
    {
        yield return new WaitForSeconds(3);
        int RandomPlant = Random.Range(0, plants.Length);
        Instantiate(plants[RandomPlant], gameObject.transform.position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        Destroy(gameObject);
    }
}
