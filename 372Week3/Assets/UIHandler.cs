using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static event Action<string> m_TextEvent;
    [SerializeField] private string UIText = "Press E to Teleport";
    public Transform tpLocation;
    private void Start()
    {
        PlayerUIManager.m_UIEvent += handleUI;
    }

    void handleUI(bool inZone)
    {
        m_TextEvent(inZone ? UIText : "");
    }
}
