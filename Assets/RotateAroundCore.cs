using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCore : MonoBehaviour
{

    public float rotationSpeed;
    public GameObject pivotObject;
    public GameObject pairElectron;
    public bool stable;
    public bool collided;
    public string kind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(pivotObject!=null)
            transform.RotateAround(pivotObject.transform.position, new Vector3(0,1,0), rotationSpeed * Time.deltaTime);
    }

}
