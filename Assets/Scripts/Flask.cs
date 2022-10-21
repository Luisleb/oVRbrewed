using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    [SerializeField] private List<string> melange;
    [SerializeField] private GameObject Cork;
    [SerializeField] private GameObject Liquid;

    public void Start()
    {
        Cork.active = false;
        Liquid.active = false;
    }

    public void SetMelange(List<string> p_melange)
    {
        melange = p_melange;
        Cork.active = true;
        Liquid.active = true;
        Liquid.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public List<string> GetMelange()
    {
        return melange;
    }
}
