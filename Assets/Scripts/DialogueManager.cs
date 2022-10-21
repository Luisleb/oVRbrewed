using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameManager Manager;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private GameObject Potion;
    [SerializeField] private GameObject Liquid;

    private int index;
    [SerializeField] public float Time_to_read;
    private float count;

    private int IDPotion;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            if (textComponent.text == lines[index])
            {
                count += Time.deltaTime;
                if (count > Time_to_read)
                {
                    NextLine();
                    count = 0;
                }
            }
        }
    }

    public void StartDialogue(int p_IDPotion)
    {
        IDPotion = p_IDPotion;
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());

    }
    
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (index == lines.Length - 1)
        {
            foreach (char c in Manager.GetListPotion()[IDPotion].p_Name.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            Liquid.GetComponent<Image>().color = Manager.GetListPotion()[IDPotion].p_Color;
            Potion.SetActive(true);
            Liquid.SetActive(true);
        }
        if(Manager.getCharacterMove() == 3)
        {
            if (Manager.getCharacterState())
            {
                foreach (char c in "Merci !")
                {
                    textComponent.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
            }
            else
            {
                foreach (char c in "Euuhh !")
                {
                    textComponent.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
            }
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void StopDialogue()
    {
        StopCoroutine(TypeLine());
        Potion.SetActive(false);
        Liquid.SetActive(false);
    }
}
