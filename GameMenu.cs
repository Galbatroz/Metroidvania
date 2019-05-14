using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menuDoJogo;
    private StatusPersonagem statusDoJogador;
    public static GameMenu instance;

    [Header("Menu e Janelas")]
    [SerializeField] private GameObject inventario;
    [SerializeField] private GameObject[] janelas;
    [SerializeField] private GameObject janelaDeConfirmacao;
    [SerializeField] private GameObject janelaDeAcao;

    [SerializeField] private Item itemAtivo;
    [SerializeField] private Text botaoDeUso, nomeDoItem, descricaoDoItem;
    [SerializeField] private SlotDeItem[] slotDeItens;
    [SerializeField] private string itemSelecionado;
    [SerializeField] private bool foraDoInventario = true;

    [Header("Botoes do Menu")]
    [SerializeField] private Button primeiroBotao;
    [SerializeField] private Button segundoBotao;
    [SerializeField] private Button terceiroBotao;

    [Header("Botoes do Inventario")]
    [SerializeField] private Button primeiroItem;

    [Header("Botoes do Menu de Ação")]
    [SerializeField] private Button acaoBotao;
    [SerializeField] private Button discartaBotao;

    [Header("Botoes do Menu de Confirmação")]
    [SerializeField] private Button confirmaBotao;
    [SerializeField] private Button cancelaBotao;

    [Header("Status do Personagem")]
    [SerializeField] private Text nomeTexto;
    [SerializeField] private Text levelTexto;
    [SerializeField] private Text expTexto;
    [SerializeField] private Text expProximoTexto;
    [SerializeField] private Text hpTexto;
    [SerializeField] private Text mpTexto;
    [SerializeField] private Text forcaTexto;
    [SerializeField] private Text vitalidadeTexto;
    [SerializeField] private Text sorteTexto;
    [SerializeField] private Text intelectoTexto;
    [SerializeField] private Text ataquePrincipalTexto;
    [SerializeField] private Text ataqueSecundarioTexto;
    [SerializeField] private Text nomeArmaSecundaria;
    [SerializeField] private Text defesaTexto;
    [SerializeField] private Text criticoTexto;
    [SerializeField] private Text fogoTexto;
    [SerializeField] private Text geloTexto;
    [SerializeField] private Text acidoTexto;
    [SerializeField] private Text esmagadorTexto;
    [SerializeField] private Text cortanteTexto;
    [SerializeField] private Text perfuranteTexto;

    [Header("Icones das Resistencias")]
    [SerializeField] private Image personagemFoto;
    [SerializeField] private Image fogoFoto;
    [SerializeField] private Image geloFoto;
    [SerializeField] private Image acidoFoto;
    [SerializeField] private Image esmagadorFoto;
    [SerializeField] private Image cortanteFoto;
    [SerializeField] private Image perfuranteFoto;

    [Header("Nome dos Equipamentos")]
    [SerializeField] private Text nomeLuva;
    [SerializeField] private Text nomeArmadura;
    [SerializeField] private Text nomeElmo;
    [SerializeField] private Text nomeColar;
    [SerializeField] private Text nomeBota;
    [SerializeField] private Text nomeAnel;
    [SerializeField] private Text nomeBerloque;
    [SerializeField] private Text nomeArmaPrimaria;

    [Header("Sprites dos Equipamentos")]
    [SerializeField] private Image spriteLuva;
    [SerializeField] private Image spriteArmadura;
    [SerializeField] private Image spriteElmo;
    [SerializeField] private Image spriteColar;
    [SerializeField] private Image spriteBota;
    [SerializeField] private Image spriteAnel;
    [SerializeField] private Image spriteBerloque;
    [SerializeField] private Image spriteArmaPrimaria;

    [Header("Status da Armadura")]
    [SerializeField] private Text armaduraDefesa;
    [SerializeField] private Text armaduraResistenciaFogo;
    [SerializeField] private Text armaduraResistenciaGelo;
    [SerializeField] private Text armaduraResistenciaAcido;
    [SerializeField] private Text armaduraResistenciaCortante;
    [SerializeField] private Text armaduraResistenciaPerfurante;
    [SerializeField] private Text armaduraResistenciaEsmagador;

    [Header("Status da Colar")]
    [SerializeField] private Text colarDefesa;
    [SerializeField] private Text colarCritico;
    [SerializeField] private Text colarResistenciaFogo;
    [SerializeField] private Text colarResistenciaGelo;
    [SerializeField] private Text colarResistenciaAcido;
    [SerializeField] private Text colarResistenciaCortante;
    [SerializeField] private Text colarResistenciaPerfurante;
    [SerializeField] private Text colarResistenciaEsmagador;

    [Header("Status da Luva")]
    [SerializeField] private Text luvaDefesa;
    [SerializeField] private Text luvaCritico;
    [SerializeField] private Text luvaResistenciaFogo;
    [SerializeField] private Text luvaResistenciaGelo;
    [SerializeField] private Text luvaResistenciaAcido;
    [SerializeField] private Text luvaResistenciaCortante;
    [SerializeField] private Text luvaResistenciaPerfurante;
    [SerializeField] private Text luvaResistenciaEsmagador;

    [Header("Status da Bota")]
    [SerializeField] private Text botaDefesa;
    [SerializeField] private Text botaResistenciaFogo;
    [SerializeField] private Text botaResistenciaGelo;
    [SerializeField] private Text botaResistenciaAcido;
    [SerializeField] private Text botaResistenciaCortante;
    [SerializeField] private Text botaResistenciaPerfurante;
    [SerializeField] private Text botaResistenciaEsmagador;

    [Header("Status da Anel")]
    [SerializeField] private Text anelCritico;
    [SerializeField] private Text anelResistenciaFogo;
    [SerializeField] private Text anelResistenciaGelo;
    [SerializeField] private Text anelResistenciaAcido;
    [SerializeField] private Text anelResistenciaCortante;
    [SerializeField] private Text anelResistenciaPerfurante;
    [SerializeField] private Text anelResistenciaEsmagador;

    [Header("Status da Berloque")]
    [SerializeField] private Text berloqueCritico;
    [SerializeField] private Text berloqueResistenciaFogo;
    [SerializeField] private Text berloqueResistenciaGelo;
    [SerializeField] private Text berloqueResistenciaAcido;
    [SerializeField] private Text berloqueResistenciaCortante;
    [SerializeField] private Text berloqueResistenciaPerfurante;
    [SerializeField] private Text berloqueResistenciaEsmagador;

    [Header("Status das Armas")]
    [SerializeField] private Text armaPrimariaDano;
    [SerializeField] private Text armasCritico;
    [SerializeField] private Text armasAcidoResistencia;
    [SerializeField] private Text armasFogoResistencia;
    [SerializeField] private Text armasGeloResistencia;
    [SerializeField] private Text armasEsmagadorResistencia;
    [SerializeField] private Text armasCortanteResistencia;
    [SerializeField] private Text armasPerfuranteResistencia;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        NavegarMenu();
        AtualizaMenu();
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
    } //Remove o item do Inventario.

    public void AbrirStatus()
    {
        AtualizaMenu();
    }

    public void TocaSomDoBotao()
    {
        AudioManager.instance.PlaySFX(0);
    } //Toca FX navegação do Menu.

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
    } //Pede Confirmação após Equipar/Usar Item.

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
    
}
