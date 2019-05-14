using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotDeItem : MonoBehaviour
{

    public Image ImagemDoSlot;
    public Text quantidadeTexto;
    public int valorDoSlot;

    public void Press()
    {
        if (GameMenu.instance.menuDoJogo.activeInHierarchy)
        {
            if(GameManager.instance.itensEmPosse[valorDoSlot] != "")
            {
                GameMenu.instance.SelecionarItem(GameManager.instance.PegaDetalheDoItem(GameManager.instance.itensEmPosse[valorDoSlot]));
                GameMenu.instance.AbrirJanelaDeAcao();

            }
        }
        //Adicionar Verificacao de Janela de Shop.
    }
}
