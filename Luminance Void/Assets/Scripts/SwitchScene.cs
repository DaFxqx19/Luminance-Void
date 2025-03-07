using System.Collections;
using System.Collections.Generic;
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
        }
    }
}