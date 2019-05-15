using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFadeIn : MonoBehaviour
{
    private SpriteRenderer[] sprites;
    [SerializeField]
    private float fadeInTime = .5f;
    [SerializeField]
    private float startingOpacity;
    private float timer;
    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        fade = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fade)
        {
            timer += Time.fixedDeltaTime;
            if (timer > fadeInTime)
            {
                SetOpacity(1.0f);
                fade = false;
            }
            else
            {
                float opacity = timer / fadeInTime;
                SetOpacity(opacity);
            }
        }
    }

    public void FadeIn()
    {
        fade = true;
        timer = 0;
        SetOpacity(startingOpacity);
    }

    private void SetOpacity(float opacity)
    {
        foreach (SpriteRenderer sprite in sprites)
        {
            if (!sprite.name.Equals("Glow"))
            {
                Color color = sprite.color;
                sprite.color = new Color(color.r, color.g, color.b, opacity);
            }
        }
    }
}
