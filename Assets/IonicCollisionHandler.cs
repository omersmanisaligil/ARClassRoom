using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicCollisionHandler : MonoBehaviour
{
    GameObject pairElectron;
    GameObject pairCore;
    private RotateAroundCore myScript;
    private RotateAroundCore pairScript;
    
    private void OnCollisionEnter(Collision otherElectron)
    {
        pairElectron = otherElectron.gameObject;
        //fetch the obtained electron's core
        pairScript = pairElectron.GetComponent<RotateAroundCore>();
        pairCore = pairScript.pivotObject;
        //assign it as your pivot object for all of your components
        //so that all can turn around it
        myScript = GetComponent<RotateAroundCore>();
        myScript.pivotObject = pairCore;
        GameObject.FindWithTag("UnstableTorus").SetActive(false);
    }
}
