using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKeyFade : MonoBehaviour
{
    private SpriteRenderer sprite;
    private SpriteRenderer glowSprite;
    [SerializeField]
    private float fadeTime = .5f;
    private float minOpacity = 0;
    private float maxOpacity = 1;
    private float timer;
    private bool fading;
    private bool fadeIn;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        fading = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fading)
        {
            timer += Time.fixedDeltaTime;
            if (timer > fadeTime)
            {
                if (fadeIn)
                {
                    SetOpacity(maxOpacity);
                }
                else
                {
                    SetOpacity(minOpacity);
                }
                fading = false;
            }
            else
            {
                float opacity;
                if (fadeIn)
                {
                    opacity = minOpacity + timer / fadeTime;
                }
                else
                {
                    opacity = maxOpacity - timer / fadeTime;
                }
                SetOpacity(opacity);
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
        fading = true;
        timer = 0;
        SetOpacity(minOpacity);
    }

    public void FadeOut()
    {
        fadeIn = false;
        fading = true;
        timer = 0;
        SetOpacity(maxOpacity);
    }

    public void MakeInvisible()
    {
        SetOpacity(0);
    }

    private void SetOpacity(float opacity)
    {
        Color color = sprite.color;
        sprite.color = new Color(color.r, color.g, color.b, opacity);

    }

}
