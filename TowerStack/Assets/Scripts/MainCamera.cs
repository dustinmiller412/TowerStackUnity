using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    public static void UpdateCamera()
    {
        float currentYPosition = Camera.main.transform.position.y;
        float yIncrement = GameManager.count < 15 ? 0.25f : 0.5f;

        Camera.main.transform.position = new Vector3(2.7f, currentYPosition + yIncrement, 3.1f);
        Camera.main.orthographicSize -= .07f;

        if (MovingSlab.done)
        {
            Camera.main.orthographicSize = 12;
            Camera.main.transform.position = new Vector3(2.7f, (GameManager.count / 3), 3.1f);
        }
    }

}
