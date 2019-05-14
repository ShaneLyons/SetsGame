using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonScript : MonoBehaviour
{
	public GameObject tutorialLeft, tutorialRight, tutorialUp, tutorialDoubleJump1, tutorialDoubleJump2;
	bool hasMovedLeft, hasMovedRight, hasMovedUp, hasDoubleJumped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMovedLeft && Input.GetKeyDown(KeyCode.LeftArrow)){
        	hasMovedLeft = true;
        	maybeDisableLeftRight();
        }

        if (!hasMovedRight && Input.GetKeyDown(KeyCode.RightArrow)){
        	hasMovedRight = true;
        	maybeDisableLeftRight();
        }

        if (!hasMovedUp && Input.GetKeyDown(KeyCode.UpArrow)){
        	hasMovedUp = true;
        	tutorialUp.SetActive(false);
        	tutorialDoubleJump1.SetActive(true);
        	tutorialDoubleJump2.SetActive(true);
        }
        
        /*
        //ebug.Log(velocity);
        if(!hasDoubleJumped && Input.GetKeyUp(KeyCode.UpArrow) && GetComponent<Rigidbody2D>().velocity.y != 0){
        	tutorialDoubleJump1.SetActive(false);
        	tutorialDoubleJump2.SetActive(false);
        }
        */
    }

    void maybeDisableLeftRight(){
    	if(hasMovedLeft && hasMovedRight){
    		tutorialLeft.SetActive(false);
    		tutorialRight.SetActive(false);
    		tutorialUp.SetActive(true);
    	}
    }
}
