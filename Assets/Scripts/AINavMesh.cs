using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AINavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] destinations = new Transform[5];
    [SerializeField] private HidingSpot[] _hidingSpots = new HidingSpot[5];

    private NavMeshAgent navMeshAgent;

    private int currentIndex;

    private void Start() {
      currentIndex = 0;
    }

    private void Awake() {
      navMeshAgent = GetComponent<NavMeshAgent>();
    }

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    private readonly Collider[] _colliders = new Collider[3];

    [SerializeField] private FieldOfView _fieldOfView;

    private bool _lockedOn = false;
    private bool _CR_running = false;

    [SerializeField] private Interactor _player;

    [SerializeField] private AudioSource _detectSound;

    private void Update() {

      var _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
      if (_numFound > 0)
      {
        var interactable = _colliders[0];
        if (interactable != null && (_lockedOn || (!_fieldOfView.canSeePlayer && !_player.isHiding)))
        {
          SceneManager.LoadScene("GameOver");
        }
      }
      if (_CR_running) return;
      // Debug.Log("locked on: "+_lockedOn);
      if (_fieldOfView.canSeePlayer) {
        // Debug.Log("boom headshot");
        if (!_CR_running) StartCoroutine(LockOn());
        navMeshAgent.destination = _fieldOfView.playerRef.transform.position;
        navMeshAgent.speed = 5;
        navMeshAgent.acceleration = 16;
        navMeshAgent.angularSpeed = 240;
      }
      else
      {
        navMeshAgent.speed = 2;
        navMeshAgent.acceleration = 8;
        navMeshAgent.angularSpeed = 120;
        // Quaternion targetRotation = Quaternion.LookRotation(movePositionTransform.position - navMeshAgent.transform.position);
        // navMeshAgent.transform.rotation = Quaternion.Slerp(navMeshAgent.transform.rotation, targetRotation, 1 * Time.deltaTime);
        navMeshAgent.destination = destinations[currentIndex].position;
        if (!navMeshAgent.pathPending)
        {
          if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
          {
            if ((!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f) && currentIndex < _hidingSpots.Length - 1)
            {
              // Debug.Log("hello");
              if (_hidingSpots[currentIndex].occupied) SceneManager.LoadScene("GameOver");
              currentIndex = currentIndex + 1;
            }
            else if (currentIndex == _hidingSpots.Length - 1)
            {
              currentIndex = 0;
            }
          }
        }
      }
      // if (navMeshAgent.remainingDistance != Mathf.Infinity && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance == 0 && currentIndex < 4)
      // {
      //   Debug.Log("hello");
      //   currentIndex = currentIndex + 1;
      // }
    }
    IEnumerator LockOn()
    {
      _CR_running = true;
      _detectSound.Play();
      _lockedOn = true;
      yield return new WaitForSeconds(3);
      _lockedOn = false;
      _CR_running = false;
    }
    // private void OnCollisionEnter(Collision other) 
    // {
    //   Debug.Log("bump");
    //   if (other.gameObject.CompareTag("Player"))
    //   {
    //     SceneManager.LoadScene("GameOver");
    //   }  
    // }
}
