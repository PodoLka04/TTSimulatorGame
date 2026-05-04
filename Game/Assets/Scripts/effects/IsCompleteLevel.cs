using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCompleteLevel : MonoBehaviour
{
    [SerializeField] private int cnt = 1; // Число от 1 до 9
    [SerializeField] private GameObject[] targetObjects; // Массив из 9 объектов

    private void Start()
    {
        // Первый switch - проверка состояния ключа
        bool isKeyActive = false;
        switch (cnt)
        {
            case 1: isKeyActive = Data.Instance.Key1; break;
            case 2: isKeyActive = Data.Instance.Key2; break;
            case 3: isKeyActive = Data.Instance.Key3; break;
            case 4: isKeyActive = Data.Instance.Key4; break;
            case 5: isKeyActive = Data.Instance.Key5; break;
            case 6: isKeyActive = Data.Instance.Key6; break;
            case 7: isKeyActive = Data.Instance.Key7; break;
            case 8: isKeyActive = Data.Instance.Key8; break;
            case 9: isKeyActive = Data.Instance.Key9; break;
        }

        // Второй switch - активация объекта
        if (isKeyActive && targetObjects != null && targetObjects.Length >= cnt)
        {
            switch (cnt)
            {
                case 1: targetObjects[0].SetActive(true); break;
                case 2: targetObjects[1].SetActive(true); break;
                case 3: targetObjects[2].SetActive(true); break;
                case 4: targetObjects[3].SetActive(true); break;
                case 5: targetObjects[4].SetActive(true); break;
                case 6: targetObjects[5].SetActive(true); break;
                case 7: targetObjects[6].SetActive(true); break;
                case 8: targetObjects[7].SetActive(true); break;
                case 9: targetObjects[8].SetActive(true); break;
            }
        }
    }
}
