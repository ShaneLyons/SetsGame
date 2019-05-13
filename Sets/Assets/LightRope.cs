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
    private bool lit = false;
    private int lastLight = 0;

    public void Setup()
    {
        lights = new List<GameObject>();
        lr = GetComponent<LineRenderer>();

        for(int i = 0; i < lr.positionCount; i++)
        {
            lights.Add(Instantiate(light, lr.GetPosition(i), Quaternion.identity, this.transform));
            lights[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lit)
        {
            timer += Time.deltaTime;
            for (int i = 0; i < lastLight; i++)
            {
                if (timer > interval * i)
                {
                    lights[i].SetActive(true);
                    lights[i].transform.position = lr.GetPosition(i);
                }
            }
        }
    }

    public void TurnOn(float percentage)
    {
        lit = true;
        // set the ending of where the light is based on the percentage dropped in
        lastLight = (int) (percentage * lr.positionCount);
        // needed to make the last bit of light up look normal
        float halfwayTime = .25f * interval * lr.positionCount;
        timer = lastLight == 0 ? 0 : halfwayTime;
    }

    public void TurnOff()
    {
        lit = false;
        for (int i = 0; i < lr.positionCount; i++)
        {
            lights[i].SetActive(false);
        }
    }
}
