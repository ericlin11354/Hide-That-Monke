using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    [SerializeField] private string _prompt;
    public Animator openandclose;
    public bool open;

    void Start()
		{
			open = false;
		}

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
      // Debug.Log("Opening door");
      if (open == false)
      {
        StartCoroutine(opening());
      }
      else
      {
        StartCoroutine(closing());
      }
      return true;
    }

    IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}
}
