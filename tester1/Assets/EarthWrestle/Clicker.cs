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
    bool fail = false, win = false;
    string display;
    public Text clickRate;
    public Text clickRequirement;
    float currentTime1;

    [SerializeField] Text countdownText;
    void Start()
    {
        cps = 5f;
        display = "Click!";
        currentTime1 = 3f;
    }

    void Update()
    {
        //currentTime1 -= 1 * Time.deltaTime;
        //countdownText.text = currentTime1.ToString("0");

        //if (currentTime1 > 0) cps = 5f;
        //if (currentTime1 <= 0)
        {
            countdownText.text = "";
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
    public void clicker()
    {
            
    }
}
