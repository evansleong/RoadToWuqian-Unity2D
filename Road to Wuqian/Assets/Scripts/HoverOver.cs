using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hp;
    [SerializeField] private AudioClip hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(hoverSound);
        hp.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hp.SetActive(false);
        gameObject.SetActive(true);
    }

}
