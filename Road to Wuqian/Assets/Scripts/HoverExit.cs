using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverExit : MonoBehaviour, IPointerExitHandler
{
    public GameObject he;

    public void OnPointerExit(PointerEventData eventData)
    {
        he.SetActive(true);
        gameObject.SetActive(false);
    }

}
