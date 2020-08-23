using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode _quitKey = KeyCode.Escape;
    [SerializeField] KeyCode _reloadKey = KeyCode.R;
    private void Update()
    {
        if (Input.GetKeyDown(_quitKey))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(_reloadKey))
        {
            Scene _curScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(_curScene.name);
        }
    }
}
