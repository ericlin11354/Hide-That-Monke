using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    [SerializeField] public GameObject _player;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private Iinteractable _interactable;

    [SerializeField] public bool isHiding = false;

    public void setIsHiding(bool hidingStatus)
    {
      isHiding = hidingStatus;
      if (isHiding == true) _player.SetActive(false);
      else {
        _player.SetActive(true);
      }
    }

    private void Update()
    {

      _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

      if (_numFound > 0)
      {
        _interactable = _colliders[0].GetComponent<Iinteractable>();

        if (_interactable != null)
        {
          if (_interactable.InteractionPrompt == "Banana") _interactable.Interact(this);
          if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
          if (Keyboard.current.eKey.wasPressedThisFrame)
          { 
            _interactable.Interact(this);
          } 
        }
      }
      else
      {
        if (_interactable != null) _interactable = null;
        if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
      }
    }

}
