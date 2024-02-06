using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI playAgain;

    // Update is called once per frame
    private void Update()
    {
        if (MovingSlab.done)
        {
            scoreLabel.text = $"Score: {GameManager.count - 1}";
            playAgain.text = $"Click to play again!";
        }
    }

    
}
