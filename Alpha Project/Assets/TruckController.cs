using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class TruckController : MonoBehaviour
{
    public Button placeFirstButton;
    public Button placeSecondButton;
    public Button placeThirdButton;
    public Button placeFourthButton;

    public NavMeshAgent navMeshAgent;
    public GameObject placefirst;
    public GameObject placeSecond;
    public GameObject placeThird;
    public GameObject placeFourth;

    private Vector3 placefirstPos;
    private Vector3 placeSecondPos;
    private Vector3 placeThirdPos;
    private Vector3 placeFourthPos;

    public ProgressBar progressBarfirstPos;
    public ProgressBar progressBarSecondPos;
    public ProgressBar progressBarThirdPos;
    public ProgressBar progressBarFourthPos;

    public GameObject placeOneForward;
    public GameObject placeOneBackward;
    public GameObject placeTwoForward;
    public GameObject placeTwoBackward;
    public GameObject placeThreeForward;
    public GameObject placeThreeBackward;
    public GameObject placeFourForward;
    public GameObject placeFourBackward;

    public Vector3[] queue;
    int f;
    int r;

    private GameObject tempDirGameObject;

    private int vehicleIndex;
    public int vehicleNumber;
    public TextMeshProUGUI selectedVehicle;

    private void Awake()
    {
        f = -1;
        r = -1;

        placeFirstButton.onClick.AddListener(MoveFirstPlace);
        placeSecondButton.onClick.AddListener(MoveSecondPlace);
        placeThirdButton.onClick.AddListener(MoveThirdPlace);
        placeFourthButton.onClick.AddListener(MoveFourthPlace);

        placefirstPos = placefirst.gameObject.transform.position;
        placeSecondPos = placeSecond.gameObject.transform.position;
        placeThirdPos = placeThird.gameObject.transform.position;
        placeFourthPos = placeFourth.gameObject.transform.position;

        vehicleIndex = 0;
        selectedVehicle.text = "Yellow Tractor Selected";
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.gameObject.CompareTag("tractoryellow"))
                {
                    vehicleIndex = 0;
                    selectedVehicle.text = "Yellow Tractor Selected";
                }
                else if(raycastHit.collider.gameObject.CompareTag("tractorred"))
                {
                    vehicleIndex = 1;
                    selectedVehicle.text = "Red Tractor Selected";
                }
            }
        }
    }


    void AssignQueue(Vector3 vector3)
    {
        if (vehicleIndex == vehicleNumber)
        {
            Debug.Log(gameObject.name);

            if (f == -1)
            {
                f = 0;
                r = 0;
                queue[r] = vector3;
                r += 1;
            }
            else if (r >= (queue.Length) - 1)
            {
                Debug.Log("Queue is full");
            }
            else
            {
                queue[r] = vector3;
                r += 1;
            }
        }
    }

    void MoveFirstPlace()
    {
        AssignQueue(placefirstPos);
    }

    void MoveSecondPlace()
    {
        AssignQueue(placeSecondPos);
    }

    void MoveThirdPlace()
    {
        AssignQueue(placeThirdPos);
    }

    void MoveFourthPlace()
    {
        AssignQueue(placeFourthPos);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == tempDirGameObject)
        {
            if ((f > -1) && (f <= r))
            {
                navMeshAgent.SetDestination(queue[f]);
            }
        }
        

        else
        {
                if ((f > -1) && (f <= r))
                {
                    if (other.gameObject.CompareTag("place1") && (queue[f] == placeSecondPos))
                    {
                        StartCoroutine(GreenSignal(progressBarfirstPos));
                        StartCoroutine(PauseMove(placeOneForward));
                        tempDirGameObject = placeOneForward;
                    }

                    else if (other.gameObject.CompareTag("place1") && (queue[f] == placeThirdPos))
                    {
                        StartCoroutine(GreenSignal(progressBarfirstPos));
                        StartCoroutine(PauseMove(placeTwoForward));
                        tempDirGameObject = placeTwoForward;
                    }

                    else if (other.gameObject.CompareTag("place2") && (queue[f] == placeThirdPos))
                    {
                        StartCoroutine(GreenSignal(progressBarSecondPos));
                        StartCoroutine(PauseMove(placeTwoForward));
                        tempDirGameObject = placeTwoForward;
                    }

                    else if (other.gameObject.CompareTag("place2") && (queue[f] == placeFourthPos))
                    {
                        StartCoroutine(GreenSignal(progressBarSecondPos));
                        StartCoroutine(PauseMove(placeThreeForward));
                        tempDirGameObject = placeThreeForward;
                    }

                    else if (other.gameObject.CompareTag("place3") && (queue[f] == placeFourthPos))
                    {
                        StartCoroutine(GreenSignal(progressBarThirdPos));
                        StartCoroutine(PauseMove(placeThreeForward));
                        tempDirGameObject = placeThreeForward;
                    }

                    else if (other.gameObject.CompareTag("place3") && (queue[f] == placefirstPos))
                    {
                        StartCoroutine(GreenSignal(progressBarThirdPos));
                        StartCoroutine(PauseMove(placeFourForward));
                        tempDirGameObject = placeFourForward;
                    }

                    else if (other.gameObject.CompareTag("place4") && (queue[f] == placefirstPos))
                    {
                        StartCoroutine(GreenSignal(progressBarFourthPos));
                        StartCoroutine(PauseMove(placeFourForward));
                        tempDirGameObject = placeFourForward;
                    }

                    else if (other.gameObject.CompareTag("place4") && (queue[f] == placeSecondPos))
                    {
                        StartCoroutine(GreenSignal(progressBarFourthPos));
                        StartCoroutine(PauseMove(placeOneForward));
                        tempDirGameObject = placeOneForward;
                    }



                    else if (other.gameObject.CompareTag("place1") && (queue[f] == placeFourthPos))
                    {
                        StartCoroutine(GreenSignal(progressBarfirstPos));
                        StartCoroutine(PauseMove(placeFourBackward));
                        tempDirGameObject = placeFourBackward;
                    }

                    else if (other.gameObject.CompareTag("place2") && (queue[f] == placefirstPos))
                    {
                        StartCoroutine(GreenSignal(progressBarSecondPos));
                        StartCoroutine(PauseMove(placeOneBackward));
                        tempDirGameObject = placeOneBackward;
                    }

                    else if (other.gameObject.CompareTag("place3") && (queue[f] == placeSecondPos))
                    {
                        StartCoroutine(GreenSignal(progressBarThirdPos));
                        StartCoroutine(PauseMove(placeTwoBackward));
                        tempDirGameObject = placeTwoBackward;
                    }

                    else if (other.gameObject.CompareTag("place4") && (queue[f] == placeThirdPos))
                    {
                        StartCoroutine(GreenSignal(progressBarFourthPos));
                        StartCoroutine(PauseMove(placeThreeBackward));
                        tempDirGameObject = placeThreeBackward;
                    }
                }
                else
                {
                    Debug.Log("Queue is empty");
                }
            
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("place1") || other.gameObject.CompareTag("place2") || other.gameObject.CompareTag("place3") || other.gameObject.CompareTag("place4"))
        {
            if ((f > -1) && (f < r))
            {
                f += 1;
            }
            else if (f == -1)
            {
                Debug.Log("Queue is empty");
            }
            else if(f == r)
            {
                f = -1;
                r = -1;
            }
        }
    }

    IEnumerator PauseRigidBody()
    {
        yield return new WaitForSeconds(2f);
    }


    IEnumerator PauseMove(GameObject gameObject)
    {
        yield return new WaitForSeconds(2f);
        navMeshAgent.SetDestination(gameObject.transform.position);
    }

    IEnumerator GreenSignal(ProgressBar progressBar)
    {
        yield return new WaitForSeconds(2f);
        while(progressBar.BarValue < 100)
        {
            progressBar.BarValue += 1;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);

        while (progressBar.BarValue > 0)
        {
            progressBar.BarValue -= 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
