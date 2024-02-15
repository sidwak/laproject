using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAnimator : MonoBehaviour
{
    public GameObject selectedObj;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;
    private float journeyLength;
    private float startTime;

    private bool isAnimating = false;

    public static TransformAnimator Instance;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    // Start the translation animation
    public void StartTranslation(Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        if (!isAnimating)
        {
            initialPosition = startPosition;
            journeyLength = Vector3.Distance(startPosition, targetPosition);
            startTime = Time.time;
            isAnimating = true;

            StartCoroutine(AnimateTranslation(targetPosition, duration));
        }
    }

    // Start the rotation animation
    public void StartRotation(Quaternion startRotation, Quaternion targetRotation, float duration)
    {
        if (!isAnimating)
        {
            initialRotation = startRotation;
            startTime = Time.time;
            isAnimating = true;

            StartCoroutine(AnimateRotation(targetRotation, duration));
        }
    }

    // Start the scaling animation
    public void StartScaling(Vector3 startScale, Vector3 targetScale, float duration)
    {
        if (!isAnimating)
        {
            initialScale = startScale;
            startTime = Time.time;
            isAnimating = true;

            StartCoroutine(AnimateScaling(targetScale, duration));
        }
    }

    // Coroutine for translation animation
    private IEnumerator AnimateTranslation(Vector3 targetPos, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float journeyFraction = elapsedTime / duration;
            selectedObj.transform.position = Vector3.Lerp(initialPosition, targetPos, journeyFraction);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final transform values
        selectedObj.transform.position = targetPos;

        isAnimating = false;
    }

    // Coroutine for rotation animation
    private IEnumerator AnimateRotation(Quaternion targetRot, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float journeyFraction = elapsedTime / duration;
            selectedObj.transform.rotation = Quaternion.Slerp(initialRotation, targetRot, journeyFraction);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final transform values
        selectedObj.transform.rotation = targetRot;

        isAnimating = false;
    }

    // Coroutine for scaling animation
    private IEnumerator AnimateScaling(Vector3 targetScale, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float journeyFraction = elapsedTime / duration;
            selectedObj.transform.localScale = Vector3.Lerp(initialScale, targetScale, journeyFraction);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final transform values
        selectedObj.transform.localScale = targetScale;

        isAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObj != null)
        {
            // Example: Call translation on key press
            if (Input.GetKeyDown(KeyCode.T))
            {
                Vector3 targetPosition = new Vector3(5, 0, 0);
                StartTranslation(selectedObj.transform.position, targetPosition, 2f);
            }

            // Example: Call rotation on key press
            if (Input.GetKeyDown(KeyCode.R))
            {
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                StartRotation(selectedObj.transform.rotation, targetRotation, 2f);
            }

            // Example: Call scaling on key press
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vector3 targetScale = new Vector3(2, 2, 2);
                StartScaling(selectedObj.transform.localScale, targetScale, 2f);
            }
        }
    }
}

