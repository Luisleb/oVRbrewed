using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    private GameManager Manager;
    [SerializeField] private GameObject Cork;
    [SerializeField] private GameObject Liquid;
    private int IDMelange;

    private List<int> Poison = new List<int>() { 2, 3 };
    private List<int> Heal = new List<int>() { 0, 1 };
    private List<int> Invisibility = new List<int>() { 0, 3 };
    [SerializeField] private AudioSource soundEffect;

    public void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        IDMelange = -1;
        Cork.SetActive(false);
        Liquid.SetActive(false);
    }

    public void SetMelange(List<string> p_melange)
    {
        Cork.SetActive(true);
        Liquid.SetActive(true);
        List<int> ListeIDIngredient = new List<int>();
        soundEffect.Play();

        foreach (string ingrédient in p_melange)
        {
            if (ingrédient == "Mushroom 1")
                ListeIDIngredient.Add(0);
            if (ingrédient == "Mushroom 2")
                ListeIDIngredient.Add(1);
            if (ingrédient == "Mushroom 3")
                ListeIDIngredient.Add(2);
            if (ingrédient == "bat_wing")
                ListeIDIngredient.Add(3);
        }

        ListeIDIngredient.Sort();

        int count = 0;
        foreach(int id in ListeIDIngredient)
        {
            //if (Poison.Count > count)
                if (id == Poison[count])
                    count++;
        }
        if (count == ListeIDIngredient.Count)
            IDMelange = 0;


        count = 0;
        foreach (int id in ListeIDIngredient)
        {
            //if (Heal.Count > count)
                if (id == Heal[count])
                    count++;
        }
        if (count == ListeIDIngredient.Count)
            IDMelange = 1;


        count = 0;
        foreach (int id in ListeIDIngredient)
        {
            //if (Invisibility.Count > count)
                if (id == Invisibility[count])
                    count++;
        }
        if (count == ListeIDIngredient.Count)
            IDMelange = 2;


        Liquid.GetComponent<Renderer>().material.color = Manager.GetListPotion()[IDMelange].p_Color;
    }

    public int GetMelange()
    {
        return IDMelange;
    }
}
