using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PLAY : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}