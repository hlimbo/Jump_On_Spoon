using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingCheese : MonoBehaviour
{
    public Transform bitOfCheeseSpawn;
    public GameObject bitOfCheesePrefab;

    void Start()
    {
        StartCoroutine (CheckForBitsOfCheese ());   
    }

    IEnumerator CheckForBitsOfCheese ()
    {
        while (true)
        {
            yield return new WaitForSeconds (10f);

            bool makeCheese = true;
            Item[] items = FindObjectsOfType<Item> ();
            for (int i = 0; i < items.Length; i++)
            {
                if (Vector3.Distance (items[i].transform.position, bitOfCheeseSpawn.transform.position) < 25f)
                {
                    makeCheese = false;
                }
            }

            if (makeCheese)
            {
                Instantiate (bitOfCheesePrefab, bitOfCheeseSpawn.position, bitOfCheeseSpawn.rotation);
            }
        }
    }

   
}
