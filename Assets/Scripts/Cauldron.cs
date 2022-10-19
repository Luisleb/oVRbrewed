using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] Transform Mushroom1Spot;
    [SerializeField] GameObject Mushroom1Prefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Object"))
        {
            if (collision.transform.name == "Mushroom 1")
            {

            }
            if (collision.transform.name == "Mushroom 2")
            {

            }
            if (collision.transform.name == "Mushroom 3")
            {

            }
            if (collision.transform.name == "LightingPlant1")
            {

            }
            if (collision.transform.name == "PlantEx2")
            {

            }
            if (collision.transform.name == "bat_wing2")
            {

            }

        }
    }
}
