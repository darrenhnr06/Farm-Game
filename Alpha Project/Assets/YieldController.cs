using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldController : MonoBehaviour
{
    public GameObject plantOne;
    public GameObject plantTwo;
    public GameObject plantGrown;
    public string compareTag;
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(compareTag))
                {
                    GameObject plant = GameObject.Instantiate(plantOne, hit.collider.transform);
                    Debug.Log(hit.collider.gameObject.name);
                    StartCoroutine(Grow(hit.collider.transform, plant));
                }
            }
        }
    }

    IEnumerator Grow(Transform transform, GameObject temp)
    {
        yield return new WaitForSeconds(10f);
        GameObject plant = temp;
        Destroy(plant);
        GameObject HalfPlant = GameObject.Instantiate(plantTwo, transform);
        yield return new WaitForSeconds(10f);
        Destroy(HalfPlant);
        GameObject FullPlant = GameObject.Instantiate(plantGrown, transform);
    }
}
