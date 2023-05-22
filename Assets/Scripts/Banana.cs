using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, Iinteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] private BananaCounter _counter;
    [SerializeField] private GameObject _banana;
    
    private Vector3 CenterPoint;
    private float Radius = 0.25f;
    private float Speed = 2.0f;

    [SerializeField] private int _id;

    [SerializeField] private AudioSource _sound;

    void Start()
		{
      CenterPoint = _banana.transform.position;
      _prompt = "Banana";
		}

    void Update() {
      // _banana.transform.position = new Vector3(CenterPoint.position.x + Mathf.Cos(Time.time*Speed)*Radius, CenterPoint.position.y, CenterPoint.position.z + Mathf.Sin(Time.time*Speed)*Radius);
      _banana.transform.position = new Vector3(CenterPoint.x, CenterPoint.y + Mathf.Cos(Time.time*Speed)*Radius, CenterPoint.z);
      _banana.transform.Rotate(0.0f, Speed + Mathf.Sin(Time.time*Speed)*Radius, 0.0f);
    }

    public bool Interact(Interactor interactor)
    {
      _counter.incrementBanana();
      _banana.SetActive(false);
      _sound.Play();
      return true;
    }
}
