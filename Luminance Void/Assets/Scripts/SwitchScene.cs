using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            SceneManager.LoadScene(0);
            //if (SceneManager.GetActiveScene().buildIndex.Equals(1)) SceneManager.LoadScene(2);
            //if (SceneManager.GetActiveScene().buildIndex.Equals(2)) SceneManager.LoadScene(0);
        }
    }
}