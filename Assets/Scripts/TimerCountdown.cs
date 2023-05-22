using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public GameObject timerTextDisplay;
    public GameObject headerTextDisplay;
    [SerializeField] private GameObject[] blackBars = new GameObject[2];
    public int secondsLeft = 10;
    public bool takingAway = false;

    [SerializeField] private GameObject _ai;
    [SerializeField] private GameObject _ai2;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject[] _cutScenesToPlay = new GameObject[3];
    [SerializeField] private GameObject[] _cutSceneCameras = new GameObject[3];

    private bool _playedCutSceneOnce = false;

    [SerializeField] private AudioSource _prepareMusic;
    [SerializeField] private AudioSource _music;

    [SerializeField] private GameObject _bananas;

    [SerializeField] private GameObject bananaCounter;
    [SerializeField] private BananaCounter _counter;

    void Start()
    {
      Time.timeScale = 1;
      headerTextDisplay.GetComponent<TMP_Text>().text = "Hide the Monke!";
      timerTextDisplay.GetComponent<TMP_Text>().text = "" + secondsLeft;
      _ai.SetActive(false);
      _ai2.SetActive(false);
    }

    void Update()
    {
      if (takingAway == false) {
        if (secondsLeft > 0)
        {
          if (secondsLeft == 30)
          {
            // _ai.SetActive(false);
            this.Activate(1);
            _ai2.SetActive(true);
            // _ai.SetActive(true);
          }
          StartCoroutine(TimerTake());
        }
        else if (secondsLeft == 0)
        {
          if (!_playedCutSceneOnce) 
          {
            // for (int i=0; i < _bananas.transform.childCount; i++) {
            //   _bananas.transform.GetChild(i).gameObject.SetActive(true);
            // }
            _bananas.SetActive(true);
            _prepareMusic.Pause();
            _music.Play();
            _playedCutSceneOnce = true;
            this.Activate(0);
            _ai.SetActive(true);
            headerTextDisplay.GetComponent<TMP_Text>().text = "Survive 1 Min! Grab all Bananas for the Secret Ending";
            bananaCounter.SetActive(true);
            secondsLeft = 60;
          }
          else {
            // SceneManager.LoadScene("YouWin");
            if (_counter.numFound == 6) {
              _music.Pause();
              headerTextDisplay.SetActive(false);
              timerTextDisplay.SetActive(false);
              bananaCounter.SetActive(false);
              this.Activate(2);
            }
            else {
              SceneManager.LoadScene("YouWin");
            }
          }
        }
      }
    }

    public void LoadYouWin()
    {
      SceneManager.LoadScene("YouWin");
    }

    IEnumerator TimerTake()
    {
      takingAway = true;
      yield return new WaitForSeconds(1);
      secondsLeft -= 1;
      timerTextDisplay.GetComponent<TMP_Text>().text = "" + secondsLeft;
      takingAway = false;
    }

    public void Activate(int index)
    {
      Time.timeScale = 0;
      // blackBars[0].SetActive(true);
      // blackBars[1].SetActive(true);
      _cutScenesToPlay[index].SetActive(true);
      _cutSceneCameras[index].SetActive(true);
    }

    public void Deactivate(int index)
    {
      Time.timeScale = 1;
      // blackBars[0].SetActive(false);
      // blackBars[1].SetActive(false);
      _cutScenesToPlay[index].SetActive(false);
      _cutSceneCameras[index].SetActive(false);
    }
}
