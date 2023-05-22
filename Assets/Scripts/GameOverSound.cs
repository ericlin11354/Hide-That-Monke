using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{

    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source.Play();
    }
}
