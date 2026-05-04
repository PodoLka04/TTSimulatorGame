using UnityEngine;

public class SimpleDance : MonoBehaviour
{
    [Header("Настройки танца")]
    [SerializeField] private float danceSpeed = 2f;    // Скорость качания
    [SerializeField] private float danceAngle = 15f;   // Угол наклона (в градусах)
    [SerializeField] private bool danceOnStart = true; // Автозапуск

    private Quaternion startRotation;
    private float timer;

    private void Start()
    {
        startRotation = transform.rotation;
        if (danceOnStart) StartDance();
    }

    private void Update()
    {
        if (danceOnStart)
        {
            // Плавное качание через PingPong
            float angle = Mathf.PingPong(timer * danceSpeed, danceAngle * 2) - danceAngle;
            transform.rotation = startRotation * Quaternion.Euler(0, 0, angle);
            timer += Time.deltaTime;
        }
    }

    // Включить/выключить танец
    public void StartDance() => danceOnStart = true;
    public void StopDance() => danceOnStart = false;
}