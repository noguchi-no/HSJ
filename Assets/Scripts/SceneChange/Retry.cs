using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, 0.3f);
    }
}
