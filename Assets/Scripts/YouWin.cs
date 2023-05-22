using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class YouWin : MonoBehaviour
{

  public void Start()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }

  public void ReturnToMainMenu()
  {
    // StartCoroutine(LoadScene());
    SceneManager.LoadScene("MainMenu");
  }
}