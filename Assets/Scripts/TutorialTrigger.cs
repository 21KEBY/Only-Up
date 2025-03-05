using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject panneauExplicatif; // Panneau d'explication
    public string message = "Appuie sur A pour sauter !";

    private void Start()
    {
        if (panneauExplicatif != null)
            panneauExplicatif.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (panneauExplicatif != null)
            {
                panneauExplicatif.SetActive(true);
                panneauExplicatif.GetComponentInChildren<TextMeshProUGUI>().text = message;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (panneauExplicatif != null)
                panneauExplicatif.SetActive(false);
        }
    }
}
