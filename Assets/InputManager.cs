using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        if(touch.phase.Equals(TouchPhase.Began)){
            Ray raycast = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if(Physics.Raycast(raycast, out raycastHit)){
                BirdBehaviour birdScript =
                        raycastHit.collider.GetComponent<BirdBehaviour>();
                Debug.Log("hit " + raycastHit.collider.name);

                bool idle = birdScript.idle;
                bool flying = birdScript.flying;
                bool landing = birdScript.landing;

                if(raycastHit.collider.name=="blueJay"){
                    if(!flying){
                        Rigidbody rb = raycastHit.collider.GetComponent<Rigidbody>();
                        rb.AddForce((transform.forward * .7f*1)+(transform.up * .7f*1));
                        birdScript.idle = false;
                        birdScript.flying = true;
                    }/*else{
                        birdScript.flying = false;
                        birdScript.landing = true;
                    }*/
                }
            }
        }
    }
}
