using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class sceneChange : MonoBehaviour
{
    public float changeTime;
    public int num;

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if ( Input.GetMouseButtonDown(0))
        {
                SceneManager.LoadScene(num);

          

        }else if (changeTime <= 0)
        {
            SceneManager.LoadScene(num);

        }
      
    }
}
