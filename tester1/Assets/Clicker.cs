using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
public class ClickRate : MonoBehaviour
{
    float lastTime, cps, clickReq = 4f;
    int count = 0;
    bool fail = false, fail2 = false, win = false;
    string display;
    public Text clickRate;
    public Text clickRequirement;
    void Start()
    {
        cps = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fail && !win)
        {
            count++;
            float currentTime = Time.time;
            float diff = currentTime - lastTime;
            lastTime = currentTime;
            cps = 1f / diff;
            cps = Mathf.Round(cps * 10.0f) * 0.1f;
            display = cps.ToString();
            if (cps < clickReq)
            {
                fail = true;
                display = "failed!";
            }
        }
        if (count == 40 && !fail)
        {
            clickReq = 5f;
        }
        if (count == 55 && !fail)
        {
            win = true;
            display = "You won!";
        }
        clickRequirement.text = "Stay above " + clickReq.ToString() + " CPS:";
        clickRate.text = display;
    }
}
