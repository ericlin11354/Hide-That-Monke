using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{

  [SerializeField] private GameObject _tutorial1;
  [SerializeField] private GameObject _tutorial2;

  public void Start()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }

  public void Update()
  {
    if (Input.GetMouseButtonDown(0))
    { 
      if (_tutorial2.activeSelf) {
        this.LoadGame();
      }
      else if (_tutorial1.activeSelf) {
        _tutorial2.SetActive(true);
      }
    } 
  }

  public void StartGame()
  {
    _tutorial1.SetActive(true);
  }

  public void LoadGame()
  {
    // StartCoroutine(LoadScene());
    SceneManager.LoadScene("Scene_02");
  }

  public void QuitGame()
  {
    Application.Quit();
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
