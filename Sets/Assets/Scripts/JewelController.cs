using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelController : MonoBehaviour
{
    // where we should tweek colors
    private Dictionary<Jewel, Color> jewelToColor = new Dictionary<Jewel, Color>()
    {
      { Jewel.Red, Color.red },
      { Jewel.Blue, Color.blue },
      { Jewel.Green, Color.green },
      { Jewel.Purple, Color.magenta },
      { Jewel.Yellow, Color.yellow },
      { Jewel.Orange, Color.gray },
      { Jewel.White, Color.white },
    };

    [SerializeField]
    private Jewel type = Jewel.Red;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = jewelToColor[type];
    }

    public Jewel getType() {
      return type;
    }

    public void hideJewel()
    {
        sprite.enabled = false;
    }

    public void showJewel()
    {
        sprite.enabled = true;
    }
}
