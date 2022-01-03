using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] bool isCan = true;
    [SerializeField] Collider GoalCollider;

    // Update is called once per frame
    void Update()
    {
        if (isCan == false && Input.GetKey(KeyCode.Z))
        {

            canvas.SetActive(false);
            isCan = true;

        }

        if (isCan == true && Input.GetKey(KeyCode.X))
        {

            canvas.SetActive(true);
            isCan = false;
        }
    }

    void OnTriggerEnter(Collider t)
    {

        canvas.SetActive(true);
        isCan = false;
        Debug.Log("a"); // ÉçÉOÇï\é¶Ç∑ÇÈ

    }
}
