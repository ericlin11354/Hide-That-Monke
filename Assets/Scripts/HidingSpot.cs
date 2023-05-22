using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour, Iinteractable
{

    [SerializeField] private string _prompt;
    public bool occupied;

    void Start()
		{
			occupied = false;
      _prompt = "Press E to hide/unhide";
		}

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
      // Debug.Log("Opening door");
      if (occupied == false)
      {
        occupied = true;
        interactor.setIsHiding(true);
      }
      else
      {
        occupied = false;
        interactor.setIsHiding(false);
      }
      return true;
    }
}
