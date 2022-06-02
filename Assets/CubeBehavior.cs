using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    Quaternion startOrientation;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Rotate90(Vector3.left));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Rotate90(Vector3.right));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Rotate90(Vector3.forward));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Rotate90(Vector3.back));
        }
    }


    private IEnumerator Rotate90(Vector3 axis)
    {
        startOrientation = transform.rotation;
        axis = transform.InverseTransformDirection(axis);
        float amount = 0;

        while (amount <= 90)
        {
            yield return new WaitForEndOfFrame();
            amount += Time.deltaTime * 90;
            transform.rotation = startOrientation * Quaternion.AngleAxis(amount, axis);
        }
        transform.rotation = startOrientation * Quaternion.AngleAxis(90, axis);
    }
}