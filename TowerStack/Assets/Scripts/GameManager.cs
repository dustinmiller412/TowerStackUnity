using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int count = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(MovingSlab.done)
            {
                SceneManager.LoadScene("SampleScene");
                MovingSlab.done = false;
                count = 1;
            }
            else
            {
                MovingSlab.movingSlab.Stop();
            }
        }
    }
}
