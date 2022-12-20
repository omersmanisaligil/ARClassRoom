using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicCollisionHandler2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject sodiumElectron = GameObject.FindWithTag("unstableSodiumE");
        GameObject target = GameObject.FindWithTag("pair9");
        Debug.Log("debg " + target.transform.position);
        sodiumElectron.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.005f*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision otherElectron)
    {
        //GameObject sodiumElectron = GameObject.FindWithTag("unstableSodiumE");
        //GameObject.FindWithTag("UnstableTorus").SetActive(false);
        //sodiumElectron.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 15f*Time.deltaTime);
    }
}
