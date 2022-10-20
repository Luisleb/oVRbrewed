using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    float beginTime = 0;

    [SerializeField] private Transform spotMushroom;
    [SerializeField] private CapsuleCollider mushroomsCollider;
    [SerializeField] private List<GameObject> ListCharacters;
    [SerializeField] private Transform PositionSpawn;
    private GameObject Character;
    private int CharacterID;
    private int CharacterMove;
    public int m_speed;

    [SerializeField] private bool waiting_potion;
    [SerializeField] private bool PreparingPotion;
 
    private void Start()
    {
        StartTime();
        PreparingPotion = false;
        CharacterMove = 0;
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

            Character = Instantiate(ListCharacters[ CharacterID ]);

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
                }
            }
        }
        if (!waiting_potion && CharacterMove == 2 && Character.transform.eulerAngles.y < 90)
        {
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

    public void CollideMushroom()
    {

    }

}