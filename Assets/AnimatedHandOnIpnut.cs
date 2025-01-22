using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //On appèle le input systeme de Unity pour ecouter les input du systeme
public class AnimatedHandOnIpnut : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;//variable public = variable modifiable dans l'editor Unity
    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>(); //Permettre de savoir la valeur du bouton puisque c'est une value 
        handAnimator.SetFloat("Trigger", triggerValue)
        Debug.Log(triggerValue);
    }
}
