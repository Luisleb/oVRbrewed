using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cauldron : MonoBehaviour
{
    List<string> melange = new List<string>();

    string[] recipe1 = new string[] { "Mushroom 1", "LightingPlant1"}; //lumiere jaune
    string[] recipe2 = new string[] { "Mushroom 1", "Mushroom 3", "bat_wing2"}; //invisibilité blanche
    string[] recipe3 = new string[] { "Mushroom 2", "bat_wing2", "PlantEx2"}; //heal rouge
    string[] recipe4 = new string[] { "Mushroom 3", "PlantEx2" }; //poison

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Object" && collision.transform.GetComponent<XRGrabInteractable>().isSelected == false)
        {
            melange.Add(collision.transform.name);
            collision.transform.localPosition = new Vector3(0, 0, 0);
        }
        if (collision.transform.tag == "Fiole" && GameManager.Instance.IsWaitingPotion())
        {
            collision.transform.GetComponent<Flask>().SetMelange(melange); 
            //Reset de la marmite
            melange = new List<string>();
        }
    }
}
