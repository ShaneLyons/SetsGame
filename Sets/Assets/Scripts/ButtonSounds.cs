using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public bool isBackButton;

    public void OnPointerEnter(PointerEventData ped)
    {
        FindObjectOfType<AudioManagerController>().Play("MouseOverButton");
    }

    public void OnPointerDown(PointerEventData ped)
    {
        if (!isBackButton)
        {
            FindObjectOfType<AudioManagerController>().Play("MouseClickButton");
        } else {
            FindObjectOfType<AudioManagerController>().Play("MouseClickButtonBack");
        }
    }
}
