using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //On appèle le input systeme de Unity pour ecouter les input du systeme
public class AnimatedHandOnIpnut : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;//variable public = variable modifiable dans l'editor Unity
    public InputActionProperty gripAnimationAction;

    public Animator handAnimator; //Appelle du composant animator de Unity 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Pas Utile 
        float triggerValue = pinchAnimationAction.action.ReadValue<float>(); //Permettre de savoir la valeur du bouton pressé puisque c'est une value 
        handAnimator.SetFloat("Trigger", triggerValue);//On va récupérer l'input afin de chnager la valeur de l'animator pour décleencher l'animation 

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
        Debug.Log(gripValue);
        
    }
}
