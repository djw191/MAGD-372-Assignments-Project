using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public static event Action<bool> m_UIEvent;
    [SerializeField] private Movement movement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UITrigger"))
        {
            movement.tpDest = other.gameObject.GetComponent<UIHandler>().tpLocation;
            m_UIEvent(true);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UITrigger"))
        {
            movement.tpDest = null;
            m_UIEvent(false);
        }
    }
}
