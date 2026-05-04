using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Video1Key : MonoBehaviour
{ 

    
    [SerializeField] private GameObject Vid1Panel;
    [SerializeField] private GameObject BlockPanel;
    [SerializeField] private int cnt;




    // Start is called before the first frame update
    private void OnEnable()
    {
        Vid1Panel.SetActive(false);
        Vid1Panel.transform.localScale = Vector3.zero;
        BlockPanel.SetActive(false);
        BlockPanel.transform.localScale = Vector3.zero;
    }

   

        public void NoAccess1()
        {
        bool isUnlocked;
        switch (cnt)
        {
            case 1: isUnlocked = Data.Instance.Key1; break;
            case 2: isUnlocked = Data.Instance.Key2; break;
            case 3: isUnlocked = Data.Instance.Key3; break;
            case 4: isUnlocked = Data.Instance.Key4; break;
            case 5: isUnlocked = Data.Instance.Key5; break;
            case 6: isUnlocked = Data.Instance.Key6; break;
            case 7: isUnlocked = Data.Instance.Key7; break;
            case 8: isUnlocked = Data.Instance.Key8; break;
            case 9: isUnlocked = Data.Instance.Key9; break;



            default: isUnlocked = false; break;
        }

        if (!isUnlocked)
        {
            // Активируем панель и сбрасываем масштаб
            Vid1Panel.SetActive(true);
                Vid1Panel.transform.localScale = Vector3.zero;
                BlockPanel.SetActive(true);
                BlockPanel.transform.localScale = Vector3.zero;

                // Создаем последовательность анимаций
                Sequence vid1Sequence = DOTween.Sequence();

                // 1. Анимация появления (1.5 сек)
                vid1Sequence.AppendCallback(() => {
                    BlockPanel.transform.localScale = Vector3.one; // Мгновенный масштаб 1
                    BlockPanel.SetActive(true);
                }); // На всякий случай включаем

                vid1Sequence.Append(Vid1Panel.transform.DOScale(1, 1.5f).SetEase(Ease.OutBack));
                // 2. Ждем 3 секунды
                vid1Sequence.AppendInterval(0.3f);

                // 3. Анимация исчезания (1.5 сек)
                vid1Sequence.Append(Vid1Panel.transform.DOScale(0, 1.5f).SetEase(Ease.InBack));
                vid1Sequence.Append(BlockPanel.transform.DOScale(0, 0.2f).SetEase(Ease.InBack));


                // 4. По завершении деактивируем панель
                vid1Sequence.OnComplete(() => {
                    Vid1Panel.SetActive(false);
                    BlockPanel.SetActive(false);
                });

                // Запускаем последовательность
                vid1Sequence.Play();
            }
        }

        /* private void ClNoAccess1()
         {
             Vid1Panel.SetActive(false);
         }*/

    }