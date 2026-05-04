using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ChangeKeys : MonoBehaviour
{

    [SerializeField] private int cnt;

    public void OpenKey()
    {
        switch (cnt)
        {
            case 1: Data.Instance.Key1 = true; break;
            case 2: Data.Instance.Key2 = true; break;
            case 3: Data.Instance.Key3 = true; break;
            case 4: Data.Instance.Key4 = true; break;
            case 5: Data.Instance.Key5 = true; break;
            case 6: Data.Instance.Key6 = true; break;
            case 7: Data.Instance.Key7 = true; break;
            case 8: Data.Instance.Key8 = true; break;
            case 9: Data.Instance.Key9 = true; break;
        }
        YandexGame.SaveProgress();

    }
}
