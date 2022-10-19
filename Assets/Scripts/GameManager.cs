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

    private void Start()
    {
        StartTime();
    }

    public void StartTime()
    {
        beginTime = Time.time;
    }
    public float GetTime()
    {
        return Time.time - beginTime;
    }

    public void CollideMushroom()
    {

    }

}