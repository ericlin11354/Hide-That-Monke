using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaCounter : MonoBehaviour
{
    public int numFound;
    [SerializeField] private GameObject _textCounter;

    public void Start()
    {
      numFound = 0;
    }

    public void incrementBanana()
    {
      numFound += 1;
    }

    public void Update()
    {
      _textCounter.GetComponent<TMP_Text>().text = numFound+"/6 Bananas";
    }
}
