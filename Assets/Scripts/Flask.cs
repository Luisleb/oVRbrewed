using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    [SerializeField] private List<string> melange;

    public void SetMelange(List<string> p_melange)
    {
        melange = p_melange;
    }

    public List<string> GetMelange()
    {
        return melange;
    }
}
