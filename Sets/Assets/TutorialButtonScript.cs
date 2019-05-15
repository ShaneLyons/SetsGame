using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonState{
    OFF, LEFTRIGHT, JUMP, DOUBLEJUMP, COMPLETE
}

public class TutorialButtonScript : MonoBehaviour
{
    private float startTimer = 2f;
	public GameObject tutorialLeft, tutorialRight, tutorialUp, tutorialDoubleJump1, tutorialDoubleJump2;
    private TutorialKeyFade tutorialLeftFade, tutorialRightFade, tutorialUpFade, tutorialDoubleJump1Fade, tutorialDoubleJump2Fade;
    public float leftRightYPos, jumpXPos, doubleJumpXPos, finalXPos;
	bool hasMovedLeft, hasMovedRight, hasMovedUp, hasDoubleJumped;
    private ButtonState state;

    void Awake()
    {
        state = ButtonState.OFF;
        tutorialLeftFade = tutorialLeft.GetComponent<TutorialKeyFade>();
        tutorialRightFade = tutorialRight.GetComponent<TutorialKeyFade>();
        tutorialUpFade = tutorialUp.GetComponent<TutorialKeyFade>();
        tutorialDoubleJump1Fade = tutorialDoubleJump1.GetComponent<TutorialKeyFade>();
        tutorialDoubleJump2Fade = tutorialDoubleJump2.GetComponent<TutorialKeyFade>();
        tutorialLeftFade.MakeInvisible();
        tutorialRightFade.MakeInvisible();
        tutorialUpFade.MakeInvisible();
        tutorialDoubleJump1Fade.MakeInvisible();
        tutorialDoubleJump2Fade.MakeInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer > 0){
            startTimer -= Time.deltaTime;
        }
        float xPos = transform.position.x;
        if(xPos > finalXPos && state == ButtonState.DOUBLEJUMP){
            state = ButtonState.COMPLETE;
            FadeOutDoubleJumpButton();
        } else if (xPos > doubleJumpXPos && state == ButtonState.JUMP)
        {
            state = ButtonState.DOUBLEJUMP;
            FadeInDoubleJumpButton();
            FadeOutJumpButton();
        } else if (xPos > jumpXPos && state == ButtonState.LEFTRIGHT)
        {
            state = ButtonState.JUMP;
            FadeInJumpButton();
            FadeOutLeftRightButtons();
        } else if (state == ButtonState.OFF && transform.position.y < leftRightYPos && startTimer < 0){
            state = ButtonState.LEFTRIGHT;
            FadeInLeftRightButtons();
        }
    }

    void FadeInLeftRightButtons(){
        tutorialLeftFade.FadeIn();
        tutorialRightFade.FadeIn();
    }

    void FadeInJumpButton(){
        tutorialUpFade.FadeIn();
    }

    void FadeInDoubleJumpButton(){
        tutorialDoubleJump1Fade.FadeIn();
        tutorialDoubleJump2Fade.FadeIn();
    }

    void FadeOutLeftRightButtons()
    {
        tutorialLeftFade.FadeOut();
        tutorialRightFade.FadeOut();
    }

    void FadeOutJumpButton()
    {
        tutorialUpFade.FadeOut();
    }

    void FadeOutDoubleJumpButton()
    {
        tutorialDoubleJump1Fade.FadeOut();
        tutorialDoubleJump2Fade.FadeOut();
    }

    void maybeDisableLeftRight(){
    	if(hasMovedLeft && hasMovedRight){
    		tutorialLeft.SetActive(false);
    		tutorialRight.SetActive(false);
    		tutorialUp.SetActive(true);
    	}
    }
}
