using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SomBotao : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        GameMenu.instance.TocaSomDoBotao();
    }
}
