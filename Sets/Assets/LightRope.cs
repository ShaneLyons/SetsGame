using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRope : MonoBehaviour
{
    public GameObject light;

    private LineRenderer lr;
    private List<GameObject> lights;
    private float interval = .05f;
    private float timer = 0;
    private bool fullyLit = false;
    private bool halfLit = false;
    private int lastLight = 0;
    private int currentIndex = 0;
    private int halfway;

    public void Setup()
    {
        lights = new List<GameObject>();
        lr = GetComponent<LineRenderer>();

        for(int i = 0; i < lr.positionCount; i++)
        {
            lights.Add(Instantiate(light, lr.GetPosition(i), Quaternion.identity, this.transform));
            lights[i].SetActive(false);
        }

        halfway = (int)lights.Count/2;
        Debug.Log(halfway);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (fullyLit)
            {
                if (currentIndex < lights.Count - 1) currentIndex += 1;
            }
            else if (halfLit)
            {
                if (currentIndex != halfway) currentIndex += (currentIndex - halfway) < 0 ? 1 : -1;
            }
            else
            {
                if (currentIndex > 0) currentIndex -= 1;
            }
            timer = interval;
            AdjustLights(currentIndex);
        }
    }

    private void AdjustLights(int maxLight){
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(i < maxLight);
            lights[i].transform.position = lr.GetPosition(i);
        }
    }

    public void TurnOn(bool halfLit)
    {
        if (halfLit)
        {
            fullyLit = false;
            this.halfLit = true;
        } else {
            fullyLit = true;
            this.halfLit = false;
        }
        // set the ending of where the light is based on the percentage dropped in

        // needed to make the last bit of light up look normal
        timer = interval;
    }

    public void TurnOff()
    {
        fullyLit = false;
        halfLit = false;
    }
}
