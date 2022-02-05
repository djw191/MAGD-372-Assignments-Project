using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class TeleporterTextHandler : MonoBehaviour
{
    private TextMeshProUGUI text;
    public Transform destination;
    private Movement movement;
    void Start()
    {
        movement = FindObjectOfType<Movement>();
        Movement.useTeleport += tp;
        UIHandler.m_TextEvent += handleText;
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "";
    }
    public void tp()
    {
        if (text.text != "")
        {
            movement.moveTo(destination);
        }
    }
    void handleText(string tpText)
    {
        text.text = tpText;
    }
}
