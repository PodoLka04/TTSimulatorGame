using UnityEngine;
using System.Collections;

public class DelayedButton : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private GameObject targetButton;  // Кнопка (перетащите в инспекторе)
    [SerializeField] private float delaySeconds = 30f; // Задержка перед показом
    [SerializeField] private float fadeTime = 0.5f;   // Время появления

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.SetActive(false);
            StartCoroutine(ShowButtonWithDelay());
        }
    }

    private IEnumerator ShowButtonWithDelay()
    {
        yield return new WaitForSeconds(delaySeconds);

        if (targetButton != null)
        {
            targetButton.SetActive(true);

            // Плавное появление через CanvasGroup
            CanvasGroup cg = targetButton.GetComponent<CanvasGroup>();
            if (cg == null) cg = targetButton.AddComponent<CanvasGroup>();

            cg.alpha = 0f;
            float timer = 0f;

            while (timer < fadeTime)
            {
                cg.alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
                timer += Time.deltaTime;
                yield return null;
            }

            cg.alpha = 1f;
        }
    }
}