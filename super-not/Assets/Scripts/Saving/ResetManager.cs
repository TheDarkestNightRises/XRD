using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance { get; private set; }

    public event System.Action ResetEvent = delegate { };

    public void Awake()
    {
        Instance = this;
    }

    public static void ResetScene()
    {
        Instance.ResetEvent();
    }
}

