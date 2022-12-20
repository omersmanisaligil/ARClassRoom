using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
   	Animator anim;
    public bool idle;
    public bool flying;
    public bool landing;
   	bool paused;
   	bool perched = false;
    public GameObject point;
    Vector3 initialPosition;

    enum birdBehaviors{
		sing,
		preen,
		ruffle,
		peck,
		hopForward,
		hopBackward,
		hopLeft,
		hopRight,
	}

    //hash variables for the animation states and animation properties
	int idleAnimationHash;
	int singAnimationHash;
	int ruffleAnimationHash;
	int preenAnimationHash;
	int peckAnimationHash;
	int hopForwardAnimationHash;
	int hopBackwardAnimationHash;
	int hopLeftAnimationHash;
	int hopRightAnimationHash;
	int worriedAnimationHash;
	int landingAnimationHash;
	int flyAnimationHash;
	int hopIntHash;
	int flyingBoolHash;
	//int perchedBoolHash;
	int peckBoolHash;
	int ruffleBoolHash;
	int preenBoolHash;
	//int worriedBoolHash;
	int landingBoolHash;
	int singTriggerHash;
	int flyingDirectionHash;
	int dieTriggerHash;
	float agitationLevel = .5f;

    // Start is called before the first frame update
    void Start()
    {
        initAnimHashes();
        initialPosition = transform.position;
        idle = true;
        landing = false;
        flying = false;
        perched = true;
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(idle){
            OnGroundBehaviors();
        }else if(flying){
            anim.applyRootMotion = false;
            anim.SetBool(flyingBoolHash,true);
            anim.SetBool(landingBoolHash, false);

            //Wait to apply velocity until the bird is entering the flying animation
            //jumpUpAndForward();
            Debug.Log("80");
            rotateAroundPoint();
        }/*else if(landing){
            Rigidbody rb = GetComponent<Rigidbody>();
            if(transform.position.y==initialPosition.y){
                idle=true;
                landing=false;
                rb.velocity = Vector3.zero;
            }
            rb.AddForce((-transform.up * 0.5f*1));
        }*/
    }


    //to be triggered by touch event
    public void jumpUpAndForward(){
        //birds fly up and away from their perch for 1 second before orienting to the next target
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.forward * .5f*1)+(transform.up * 0.5f*1));
    }

    void rotateAroundPoint(){
        if(point!=null){
            transform.RotateAround(point.transform.position, new Vector3(0,1,0), 40f * Time.deltaTime);
        }
    }

    private void OnGroundBehaviors(){
   		idle = anim.GetCurrentAnimatorStateInfo(0).nameHash == idleAnimationHash;

        //the bird is in the idle animation, lets randomly choose a behavior every 3 seconds
	    if (Random.value < Time.deltaTime*.33){
		    //bird will display a behavior
		    //in the perched state the bird can only sing, preen, or ruffle
			float rand = Random.value;
			if (rand < .3){
				DisplayBehavior(birdBehaviors.sing);
			}else if (rand < .5){
				DisplayBehavior(birdBehaviors.peck);
			}else if (rand < .6){
				DisplayBehavior(birdBehaviors.preen);	
			}else if (rand<.7){
				DisplayBehavior(birdBehaviors.ruffle);	
			}else if (!perched && rand <.85){
				DisplayBehavior(birdBehaviors.hopForward);	
			}else if (!perched && rand < .9){
				DisplayBehavior(birdBehaviors.hopLeft);	
			}else if (!perched && rand <.95){
				DisplayBehavior(birdBehaviors.hopRight);
			}else if (!perched && rand <= 1){
				DisplayBehavior(birdBehaviors.hopBackward);	
			}else{
				DisplayBehavior(birdBehaviors.sing);	
			}
			//lets alter the agitation level of the brid so it uses a different mix of idle animation next time
			anim.SetFloat ("IdleAgitated",Random.value);
        }
    }

    //Sets a variable between -1 and 1 to control the left and right banking animation
	float FindBankingAngle(Vector3 birdForward, Vector3 dirToTarget){
		Vector3 cr = Vector3.Cross (birdForward,dirToTarget);
		float ang = Vector3.Dot (cr,Vector3.up);
		return ang;
	}

    void DisplayBehavior(birdBehaviors behavior){
		idle = false;
		switch (behavior){
		case birdBehaviors.sing:
			anim.SetTrigger(singTriggerHash);			
			break;
		case birdBehaviors.ruffle:
			anim.SetTrigger(ruffleBoolHash);
			break;
		case birdBehaviors.preen:
			anim.SetTrigger(preenBoolHash);			
			break;
		case birdBehaviors.peck:
			anim.SetTrigger(peckBoolHash);			
			break;
		case birdBehaviors.hopForward:
			anim.SetInteger (hopIntHash, 1);			
			break;
		case birdBehaviors.hopLeft:
			anim.SetInteger (hopIntHash, -2);			
			break;
		case birdBehaviors.hopRight:
			anim.SetInteger (hopIntHash, 2);
			break;
		case birdBehaviors.hopBackward:
			anim.SetInteger (hopIntHash, -1);			
			break;
		}
	}

    private void initAnimHashes(){
        //collider kodu?
   		anim = gameObject.GetComponent<Animator>();

        idleAnimationHash = Animator.StringToHash("Base Layer.Idle");
		//singAnimationHash = Animator.StringToHash ("Base Layer.sing");
		//ruffleAnimationHash = Animator.StringToHash ("Base Layer.ruffle");
		//preenAnimationHash = Animator.StringToHash ("Base Layer.preen");
		//peckAnimationHash = Animator.StringToHash ("Base Layer.peck");
		//hopForwardAnimationHash = Animator.StringToHash ("Base Layer.hopForward");
		//hopBackwardAnimationHash = Animator.StringToHash ("Base Layer.hopBack");
		//hopLeftAnimationHash = Animator.StringToHash ("Base Layer.hopLeft");
		//hopRightAnimationHash = Animator.StringToHash ("Base Layer.hopRight");
		//worriedAnimationHash = Animator.StringToHash ("Base Layer.worried");
		//landingAnimationHash = Animator.StringToHash ("Base Layer.landing");
		flyAnimationHash = Animator.StringToHash ("Base Layer.fly");
		hopIntHash = Animator.StringToHash ("hop");
		flyingBoolHash = Animator.StringToHash("flying");
		//perchedBoolHash = Animator.StringToHash("perched");
		peckBoolHash = Animator.StringToHash("peck");
		ruffleBoolHash = Animator.StringToHash("ruffle");
		preenBoolHash = Animator.StringToHash("preen");
		//worriedBoolHash = Animator.StringToHash("worried");
		landingBoolHash = Animator.StringToHash("landing");
		singTriggerHash = Animator.StringToHash ("sing");
		flyingDirectionHash = Animator.StringToHash("flyingDirectionX");
		dieTriggerHash = Animator.StringToHash ("die");
		anim.SetFloat ("IdleAgitated",agitationLevel);        
    }

}
