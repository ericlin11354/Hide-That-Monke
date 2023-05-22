using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RetryGame : MonoBehaviour
{

  public void Start()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }

  public void LoadGame()
  {
    // StartCoroutine(LoadScene());
    SceneManager.LoadScene("Scene_02");
  }

  public void ReturnToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  // private bool _startedScene;

  // IEnumerator LoadScene()
  // {
  //   DontDestroyOnLoad(this);
  //   yield return new WaitForSeconds(1.5f);
  //   SceneManager.LoadScene("Scene_02");
  //   yield return new WaitForSeconds(2f);
  //   _startedScene = true;
  //   yield return new WaitUntil(() => _startedScene);
  //   yield return new WaitForSeconds(1.1f);
  //   Destroy(gameObject);
  // }
}
