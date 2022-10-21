using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    float beginTime = 0;

    public struct Potion
    {
        public string p_Name;
        public Color p_Color;
    }

    [SerializeField] private Transform spotMushroom;
    [SerializeField] private CapsuleCollider mushroomsCollider;
    [SerializeField] private List<GameObject> ListCharacters;
    [SerializeField] private List<Color> ListColorPotions;
    [SerializeField] private List<string> ListNamePotions;
    [SerializeField] private Transform PositionSpawn;
    [SerializeField] private GameObject DialogueBox;

    private List<Potion> ListPotions = new List<Potion>();

    private GameObject Character;
    private int CharacterID;
    private int CharacterMove;
    public int m_speed;
    private int IDPotion;
    private Potion pot;

    [SerializeField] private bool waiting_potion;
    [SerializeField] private bool PreparingPotion;

    string[] askedRecipe = new string[] { };
    string[] recipe1 = new string[] { "Mushroom 1", "LightingPlant1" }; //lumiere jaune
    string[] recipe2 = new string[] { "Mushroom 1", "Mushroom 3", "bat_wing2" }; //invisibilité blanche
    string[] recipe3 = new string[] { "Mushroom 2", "bat_wing2", "PlantEx2" }; //heal rouge
    string[] recipe4 = new string[] { "Mushroom 3", "PlantEx2" }; //poison

    private void Start()
    {
        StartTime();
        PreparingPotion = false;
        CharacterMove = 0;

        for (int i = 0; i<ListColorPotions.Count; i++)
        {
            pot = new Potion();
            pot.p_Color = ListColorPotions[i];
            pot.p_Name = ListNamePotions[i];

            ListPotions.Add(pot);
        }
    }

    public void StartTime()
    {
        beginTime = Time.time;
    }

    public float GetTime()
    {
        return Time.time - beginTime;
    }

    private void Update()
    {
        if (!PreparingPotion)
        {
            CharacterID = (int)Random.Range(0, ListCharacters.Count);
            IDPotion = (int)Random.Range(0, ListPotions.Count);

            Character = Instantiate(ListCharacters[CharacterID]);

            Character.transform.position = PositionSpawn.position;
            Character.transform.rotation = PositionSpawn.rotation;
            PreparingPotion = true;
        }
        CharacterScenar(CharacterID);

    }

    private void CharacterScenar(int ID)
    {
        if (CharacterMove == 0 && Character.transform.position.x < -2.2)
        {
            Character.transform.position += new Vector3(1, 0, 0) * m_speed * Time.deltaTime;
            if (Character.transform.position.x >= -2.2)
            {
                CharacterMove = 1;
            }
        }
        if (ID == 0)
        {
            if (CharacterMove == 1 && Character.transform.eulerAngles.y > 50)
            {
                Vector3 tmp = Character.transform.eulerAngles - new Vector3(0, 1, 0) * m_speed * 70 * Time.deltaTime;
                Character.transform.eulerAngles = tmp;
                if (tmp.y <= 50)
                {
                    Character.transform.eulerAngles = new Vector3(Character.transform.eulerAngles.x, 50, Character.transform.eulerAngles.z);
                    waiting_potion = true;
                    CharacterMove = 2;
                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<DialogueManager>().StartDialogue(IDPotion);
                }
            }
        }
        else
        {
            if (CharacterMove == 1 && Character.transform.eulerAngles.y > 0)
            {
                Vector3 tmp = Character.transform.eulerAngles - new Vector3(0, 1, 0) * m_speed * 70 * Time.deltaTime;
                Character.transform.eulerAngles = tmp;
                if (tmp.y <= 0)
                {
                    Character.transform.eulerAngles = new Vector3(Character.transform.eulerAngles.x, 0, Character.transform.eulerAngles.z);
                    waiting_potion = true;
                    CharacterMove = 2;
                    DialogueBox.SetActive(true);
                    DialogueBox.GetComponent<DialogueManager>().StartDialogue(IDPotion);
                }
            }
        }
        if (!waiting_potion && CharacterMove == 2 && Character.transform.eulerAngles.y < 90)
        {
            DialogueBox.GetComponent<DialogueManager>().StopDialogue();
            DialogueBox.SetActive(false);
            Character.transform.eulerAngles += new Vector3(0, 1, 0) * m_speed * 70 * Time.deltaTime;
            if (Character.transform.eulerAngles.y >= 90)
            {
                CharacterMove = 3;
            }
        }
        if (CharacterMove == 3 && Character.transform.position.x < 1)
        {
            Character.transform.position += new Vector3(1, 0, 0) * m_speed * Time.deltaTime;
            if (Character.transform.position.x >= 1)
            {
                CharacterMove = 0;
                Destroy(Character);
                PreparingPotion = false;
            }
        }

    }
    public string[] AskedRecipe()
    {
        return askedRecipe;
    }

    public bool IsWaitingPotion()
    {
        return waiting_potion;
    }

    public List<Potion> GetListPotion()
    {
        return ListPotions;
    }

    public void CollideMushroom()
    {

    }

}