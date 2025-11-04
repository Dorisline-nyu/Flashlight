using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class ResourceBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private float currentResource = 100;
    [SerializeField] private float totalResource = 100;
    [SerializeField] private bool overkill;
    
    public Light2D flashLight;
    //public SpriteRenderer spriteRenderer;

    [Header("Animation Speed")]
    [SerializeField, Range(0, 0.5f)] private float animationTime = 0.25f;
    private Coroutine fillRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ChangeOverTime();
        UpdateBar();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeOverTime();
        currentResource -= Time.deltaTime;
        CallFillAnimation();

        if(currentResource <= 0)
        {
            flashLight.intensity = 0;
            //spriteRenderer.color = Color.black;
            Debug.Log("Flash off");
        }
        else
        {
            flashLight.intensity = 4f;
            //spriteRenderer.color = Color.white;
        }
    }

    private void UpdateBar()
    {
        if (totalResource <= 0)
        {
            bar.fillAmount = 0;
            return;
        }

            float fillAmount = currentResource / totalResource;
    }
    /*
    private void ChangeOverTime()
    {
        if (totalResource > 0)
        {
            totalResource +=  Time.deltaTime;
        }
        else
        {
            Debug.Log("Out of Battery");
        }
        CallFillAnimation();
    }
    */

    public bool ChangeResourceByAmount(float amount)
    {
        if (!overkill && currentResource + amount < 0)
        return false;

        currentResource += amount;
        currentResource = Mathf.Clamp(currentResource, 0, totalResource);

        bar.fillAmount = currentResource / totalResource;

        return true;
    }

    private void CallFillAnimation()
    {
        float targetFill = currentResource / totalResource;

        if (Mathf.Approximately(bar.fillAmount, targetFill))
            return;

        if (fillRoutine != null)
            StopCoroutine(fillRoutine);

        fillRoutine = StartCoroutine(TransitionToNewValue(targetFill));
    }

    private IEnumerator TransitionToNewValue(float targetFill)
    {
        float originalFill = bar.fillAmount;
        float elapsedTime = 0.0f;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float time = elapsedTime / animationTime;
            bar.fillAmount = Mathf.Lerp(originalFill, targetFill, time);

            yield return null;
        }
    }
}
