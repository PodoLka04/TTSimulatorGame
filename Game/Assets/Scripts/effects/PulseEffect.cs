using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    [Header("Pulse Settings")]
    [SerializeField] private float pulseSpeed = 2f;    // Скорость пульсации
    [SerializeField] private float minScale = 0.9f;   // Минимальный масштаб
    [SerializeField] private float maxScale = 1.1f;   // Максимальный масштаб

    private Vector3 originalScale;
    private float timer;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Плавное изменение масштаба между min и max
        float scaleValue = Mathf.Lerp(minScale, maxScale,
            Mathf.PingPong(Time.time * pulseSpeed, 1f));

        transform.localScale = originalScale * scaleValue;
    }
}