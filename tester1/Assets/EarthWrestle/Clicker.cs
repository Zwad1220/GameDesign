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
    public staticData3 staticData3;
    string display;
    public Text clickRate;
    public Text clickRequirement;
    public Text currentCPS;
    public Text beginIn;
    float currentTime1;
    public GameObject nextButton;
    public LogicScript LogicScript;
    public GameObject Exit;
    public bool active = false;
    public AudioManager audioManager;

    [SerializeField] Text countdownText;
    void Start()
    {
        cps = 4;
        display = "Click!";
        currentTime1 = 3f;
    }

    void Update()
    {
        currentTime1 -= 1 * Time.deltaTime;
        countdownText.text = currentTime1.ToString("0");
        
        if (currentTime1 <= 0)
        {
            countdownText.text = "";
            if (Input.GetMouseButtonDown(0) && !fail && !win)
            {
                audioManager.PlaySFX(audioManager.click);
                count++;
                float currentTime = Time.time;
                float diff = currentTime - lastTime;
                lastTime = currentTime;
                cps = 1f / diff;
                cps = Mathf.Round(cps * 10.0f) * 0.1f;
                display = cps.ToString();
                if (cps < clickReq && currentTime1 < -1f)
                {
                    fail = true;
                    display = "failed!";
                    LogicScript.GameOver();
                    LogicScript.ReduceLife();
                }
            }
            if (count == 40 && !fail)
            {
                clickReq = 5f;
            }
            if (count == 55 && !fail)
            {
                win = true;
                staticData3.value = true;
                display = "You won!";
                nextButton.SetActive(true);
            }
            clickRequirement.text = "Stay above " + clickReq.ToString() + " CPS:";
            clickRate.text = display;
            currentCPS.text = "CPS:";
            beginIn.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                Exit.SetActive(true);
                active = true;
            }
            else
            {
                active = false;
                Exit.SetActive(false);
            }
        }
    }
}
