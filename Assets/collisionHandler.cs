using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    GameObject pairElectron;
    GameObject pairCore;
    private RotateAroundCore myScript;
    private RotateAroundCore pairScript;
    public int number;
    public bool collided;

    private void OnCollisionEnter(Collision otherElectron){
        pairElectron = otherElectron.gameObject;
        Debug.Log("ONCOLLISIONENTEEER");
        //fetch the obtained electron's core
        pairScript = pairElectron.GetComponent<RotateAroundCore>();
        pairCore = pairScript.pivotObject;
        //assign it as your pivot object for all of your components
        //so that all can turn around it
        myScript = GetComponent<RotateAroundCore>();
        myScript.pivotObject = pairCore;
        GameObject.FindWithTag("Torus"+number)
                .GetComponent<RotateAroundCore>().pivotObject = pairCore;
        Debug.Log("Torus"+number);
        Debug.Log(GameObject.FindWithTag("Torus"+number)
                .GetComponent<RotateAroundCore>());
        GameObject.FindWithTag("Hyd"+number)
                .GetComponent<RotateAroundCore>().pivotObject = pairCore;
    }
}
