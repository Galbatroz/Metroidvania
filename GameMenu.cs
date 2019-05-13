using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject menuDoJogo;
    public GameObject inventario;
    public GameObject[] janelas;
    public GameObject janelaDeConfirmacao;
    public GameObject janelaDeAcao;

    private StatusPersonagem statusDoJogador;

    public static GameMenu instance;

    public Item itemAtivo;
    public Text botaoDeUso, nomeDoItem, descricaoDoItem;
    public SlotDeItem[] slotDeItens;

    public string itemSelecionado;
    [Header("Botoes do Menu")]
    public Button primeiroBotao;
    public Button segundoBotao;
    public Button terceiroBotao;
    [Header("Botoes do Inventario")]
    public Button primeiroItem;
    public Button acaoBotao;
    public Button discartaBotao;
    public Button confirmaBotao;
    public Button cancelaBotao;


    public bool foraDoInventario = true;


    //Campos de Entrada do Menu.===================================
    [Header("Campos do Menu")]
    public Text nomeTexto;
    public Text levelTexto;
    public Text expTexto;
    public Text expProximoTexto;
    public Text hpTexto;
    public Text mpTexto;
    public Text forcaTexto;
    public Text vitalidadeTexto;
    public Text sorteTexto;
    public Text intelectoTexto;
    public Text ataquePrincipalTexto;
    public Text ataqueSecundarioTexto;
    public Text defesaTexto;
    public Text criticoTexto;
    public Text fogoTexto;
    public Text geloTexto;
    public Text acidoTexto;
    public Text esmagadorTexto;
    public Text cortanteTexto;
    public Text perfuranteTexto;

    public Image personagemFoto;
    public Image fogoFoto;
    public Image geloFoto;
    public Image acidoFoto;
    public Image esmagadorFoto;
    public Image cortanteFoto;
    public Image perfuranteFoto;
    //=============================================================

    //Campos dos Status
    [Header("Campos dos Status")]
    public Text nomeArmadura;
    public Text nomeElmo;
    public Text nomeLuva;
    public Text nomeColar;
    public Text nomeBota;
    public Text nomeAnel;
    public Text nomeBerloque;
    public Text nomeArmaPrimaria;
    public Text nomeArmaSecundaria;

    public Text armaduraDefesa;

    public Text armaPrimariaDano;
    public Text armaSecundariaDano;
    public Text armasCritico;
    public Text armasAcidoResistencia;
    public Text armasFogoResistencia;
    public Text armasGeloResistencia;
    public Text armasEsmagadorResistencia;
    public Text armasCortanteResistencia;
    public Text armasPerfuranteResistencia;

    void Start()
    {
        instance = this;
    }

    void Update()
    {

        NavegarMenu();
        //AtualizaMenu();
    }

    public void TrocaJanela(int numeroJanela)
    {
        for (int i = 0; i < janelas.Length; i++)
        {
            AtualizaMenu();
            if (i == numeroJanela)
            {
                janelas[i].SetActive(!janelas[i].activeInHierarchy);
            }
            else
            {
                janelas[i].SetActive(false);
            }
        }
    } // Torca as Tabs no Menu.

    public void FechaMenu()
    {
        Debug.Log("Teste");
        for (int i = 0; i < janelas.Length; i++)
        {
            janelas[i].SetActive(false);
        }

        menuDoJogo.SetActive(false);
        inventario.SetActive(false);
        janelaDeConfirmacao.SetActive(false);
        janelaDeAcao.SetActive(false);
        GameManager.instance.menuAtivo = false;

    } // Fecha o Menu.

    public void AtualizaMenu()
    {
        statusDoJogador = GameManager.instance.statusDoJogador;

        nomeTexto.text = statusDoJogador.nomePersonagem;
        levelTexto.text = statusDoJogador.levelPersonagem.ToString();
        expTexto.text = statusDoJogador.expAtual.ToString();
        expProximoTexto.text = statusDoJogador.expProximoLevel[statusDoJogador.levelPersonagem].ToString();
        hpTexto.text = statusDoJogador.hpAtual + "/" + statusDoJogador.hpMaximo;
        mpTexto.text = statusDoJogador.mpAtual + "/" + statusDoJogador.mpMaximo;
        forcaTexto.text = statusDoJogador.forca.ToString();
        vitalidadeTexto.text = statusDoJogador.vitalidade.ToString();
        sorteTexto.text = statusDoJogador.sorte.ToString();
        intelectoTexto.text = statusDoJogador.intelecto.ToString();
        ataquePrincipalTexto.text = statusDoJogador.ataqueMaoPrimaria.ToString();
        ataqueSecundarioTexto.text = statusDoJogador.ataqueMaoSecundaria.ToString();
        defesaTexto.text = statusDoJogador.defesa.ToString();
        criticoTexto.text = statusDoJogador.critico.ToString("F1") + "%";
        fogoTexto.text = statusDoJogador.resistenciaFogo.ToString("F1") + "%";
        geloTexto.text = statusDoJogador.resistenciaGelo.ToString("F1") + "%";
        acidoTexto.text = statusDoJogador.resistenciaAcido.ToString("F1") + "%";
        esmagadorTexto.text = statusDoJogador.resistenciaEsmagador.ToString("F1") + "%";
        cortanteTexto.text = statusDoJogador.resistenciaCortante.ToString("F1") + "%";
        perfuranteTexto.text = statusDoJogador.resistenciaPerfurante.ToString("F1") + "%";

        //Janela de Status
        //Arma----------------------------------------
        if (statusDoJogador.nomeMaoPrimaria != "")
        {
            nomeArmaPrimaria.text = statusDoJogador.nomeMaoPrimaria;
            armaPrimariaDano.text = statusDoJogador.armaEquipadaPrimariaDano.ToString();
            armaPrimariaDano.gameObject.SetActive(true);

            if (statusDoJogador.criticoArma > 0f)
            {
                armasCritico.gameObject.SetActive(true);
                armasCritico.text = statusDoJogador.criticoArma + "%";
            }
            else
            {
                armasCritico.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaAcidoArmaPrincipal > 0f)
            {
                armasAcidoResistencia.gameObject.SetActive(true);
                armasAcidoResistencia.text = statusDoJogador.resistenciaAcidoArmaPrincipal + "%";
            }
            else
            {
                armasAcidoResistencia.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaFogoArmaPrincipal > 0f)
            {
                armasFogoResistencia.gameObject.SetActive(true);
                armasFogoResistencia.text = statusDoJogador.resistenciaFogoArmaPrincipal + "%";
            }
            else
            {
                armasFogoResistencia.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaGeloArmaPrincipal > 0f)
            {
                armasGeloResistencia.gameObject.SetActive(true);
                armasGeloResistencia.text = statusDoJogador.resistenciaGeloArmaPrincipal + "%";
            }
            else
            {
                armasGeloResistencia.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaEsmagadorArmaPrincipal > 0f)
            {
                armasEsmagadorResistencia.gameObject.SetActive(true);
                armasEsmagadorResistencia.text = statusDoJogador.resistenciaEsmagadorArmaPrincipal + "%";
            }
            else
            {
                armasEsmagadorResistencia.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaPerfuranteArmaPrincipal > 0f)
            {
                armasPerfuranteResistencia.gameObject.SetActive(true);
                armasPerfuranteResistencia.text = statusDoJogador.resistenciaPerfuranteArmaPrincipal + "%";
            }
            else
            {
                armasPerfuranteResistencia.gameObject.SetActive(false);
            }
            if (statusDoJogador.resistenciaCortanteArmaPrincipal > 0f)
            {
                armasCortanteResistencia.gameObject.SetActive(true);
                armasCortanteResistencia.text = statusDoJogador.resistenciaCortanteArmaPrincipal + "%";
            }
            else
            {
                armasCortanteResistencia.gameObject.SetActive(false);
            }
        }
        else
        {
            nomeArmaPrimaria.text = "Vazio";
            armaPrimariaDano.gameObject.SetActive(false);
            armasCritico.gameObject.SetActive(false);
            armasFogoResistencia.gameObject.SetActive(false);
            armasGeloResistencia.gameObject.SetActive(false);
            armasAcidoResistencia.gameObject.SetActive(false);
            armasCortanteResistencia.gameObject.SetActive(false);
            armasPerfuranteResistencia.gameObject.SetActive(false);
            armasEsmagadorResistencia.gameObject.SetActive(false);
        }

        if (statusDoJogador.nomeMaoSecundaria != "")
        {
            nomeArmaSecundaria.text = statusDoJogador.nomeMaoSecundaria;
        }

        else
        {
            nomeArmaSecundaria.text = "Vazio";
            armaSecundariaDano.gameObject.SetActive(false);
        }


    } // Atializa as informaçoes do menu.

    public void SelecionarItem(Item novoItem)
    {
        itemAtivo = novoItem;

        if (itemAtivo.consumivel)
        {
            botaoDeUso.text = "Usar";
        }
        if (itemAtivo.arma || itemAtivo.armadura || itemAtivo.berloque || itemAtivo.colar || itemAtivo.bota || itemAtivo.luva || itemAtivo.elmo)
        {
            botaoDeUso.text = "Equipar";
        }

        nomeDoItem.text = itemAtivo.nomeDoItem;
        descricaoDoItem.text = itemAtivo.descricao;
    } // Seleciona um item para ser usado.

    public void UsarItem()
    {
        itemAtivo.Use();
        janelaDeConfirmacao.SetActive(false);
        AtivaSlotsInventario();
        primeiroItem.Select();
        AtualizaMenu();
    }

    public void MostraItens()
    {
        GameManager.instance.OrganizaItem();

        for (int i = 0; i < slotDeItens.Length; i++)
        {
            slotDeItens[i].valorDoSlot = i;

            if (GameManager.instance.itensEmPosse[i] != "")
            {
                slotDeItens[i].ImagemDoSlot.gameObject.SetActive(true);
                slotDeItens[i].quantidadeTexto.text = GameManager.instance.quantidadeDeItens[i].ToString();
                slotDeItens[i].ImagemDoSlot.sprite =
                GameManager.instance.PegaDetalheDoItem(GameManager.instance.itensEmPosse[i]).iconeItem;
            }
            else
            {
                slotDeItens[i].ImagemDoSlot.gameObject.SetActive(false);
                slotDeItens[i].quantidadeTexto.text = "";
            }
        }

    }

    public void DiscartaItem()
    {
        if (itemAtivo != null)
        {
            GameManager.instance.RemoveItem(itemAtivo.nomeDoItem);
            janelaDeAcao.SetActive(false);
            AtivaSlotsInventario();
            primeiroItem.Select();
            TocaSomDoBotao();
        }
    }

    public void AbrirStatus()
    {
        AtualizaMenu();
    }

    public void TocaSomDoBotao()
    {
        AudioManager.instance.PlaySFX(0);
    }

    public void AbrirJanelaDeConfirmacao()
    {
        TocaSomDoBotao();
        janelaDeConfirmacao.SetActive(true);
        confirmaBotao.interactable = true;
        cancelaBotao.interactable = true;
        janelaDeAcao.SetActive(false);
        confirmaBotao.Select();
        acaoBotao.interactable = false;
        discartaBotao.interactable = false;
    }

    public void AbrirJanelaDeAcao()
    {
        TocaSomDoBotao();
        janelaDeAcao.SetActive(true);
        acaoBotao.interactable = true;
        discartaBotao.interactable = true;
        acaoBotao.Select();
        DesativaSlotsInventario();
    }

    public void NavegarMenu()
    {
        TocaSomNavegacao();
        if (Input.GetButtonDown("Start"))
        {         
            if (menuDoJogo.activeInHierarchy)
            {
                FechaMenu();
            }
            else
            {
                TocaSomDoBotao();               
                menuDoJogo.SetActive(true);
                AtualizaMenu();
                GameManager.instance.menuAtivo = true;
                primeiroBotao.Select();
                foraDoInventario = true;
                janelas[0].SetActive(true);
                primeiroBotao.interactable = true;
                segundoBotao.interactable = true;
                terceiroBotao.interactable = true;
                AtivaSlotsInventario();
            }

        }
        if (Input.GetButtonDown("Circle") && inventario.activeInHierarchy && !janelaDeAcao.activeInHierarchy && !janelaDeConfirmacao.activeInHierarchy)
        {
            TocaSomDoBotao();
            TrocaJanela(0);
            primeiroBotao.Select();
            foraDoInventario = true;
            primeiroBotao.interactable = true;
            segundoBotao.interactable = true;
            terceiroBotao.interactable = true;
        }
        if (Input.GetButtonDown("Circle") && janelaDeAcao.activeInHierarchy && !janelaDeConfirmacao.activeInHierarchy)
        {
            TocaSomDoBotao();
            janelaDeAcao.SetActive(false);
            foraDoInventario = false;
            AtivaSlotsInventario();
            primeiroItem.Select();
        }
        if (Input.GetButtonDown("Circle") && janelaDeConfirmacao.activeInHierarchy && !janelaDeAcao.activeInHierarchy)
        {
            TocaSomDoBotao();
            janelaDeConfirmacao.SetActive(false);
            janelaDeAcao.SetActive(true);
            acaoBotao.interactable = true;
            discartaBotao.interactable = true;
            acaoBotao.Select();
        }

        if (inventario.activeInHierarchy && foraDoInventario)
        {
            primeiroItem.Select();

            foraDoInventario = false;
        }
        if (foraDoInventario == false && inventario.activeInHierarchy)
        {
            primeiroBotao.interactable = false;
            segundoBotao.interactable = false;
            terceiroBotao.interactable = false;
        }
    } //Controles do Menu.

    public void DesativaSlotsInventario()
    {
        for (int i = 0; i < slotDeItens.Length; i++)
        {
            slotDeItens[i].GetComponent<Button>().interactable = false;
        }
    }

    public void AtivaSlotsInventario()
    {
        for (int i = 0; i < slotDeItens.Length; i++)
        {
            slotDeItens[i].GetComponent<Button>().interactable = true;
        }
    }

    public void TocaSomNavegacao()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && inventario.activeInHierarchy)
        {
            TocaSomDoBotao();
        }
    }
}
