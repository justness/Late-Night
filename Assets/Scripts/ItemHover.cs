using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Conditions;

public class ItemHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int id;
    public bool condition1;
    public bool condition2;

    void Start()
    {
        Conditions.conditions[id] = 1;
        if (item)
        {
            if (!item.alt1) item.alt1 = condition1;
            if (!item.alt2) item.alt2 = condition2;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
