using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public Sprite iconeItem;

    public bool consumivel, arma, armadura, bota, luva, elmo, colar, berloque, chave;

    [Header("Raridade")]
    public bool comum;
    public bool raro;
    public bool epico;
    public bool lendario;

    [Header("Tipo de Arma")]
    public bool espadaDeUmaMao;
    public bool espadaDeDuasMaos;
    public bool lança;
    public bool adaga;

    public string nomeDoItem;

    [TextArea]
    public string descricao;

    [Header("Detalhes Consumivel")]
    public int quantidadeParaMudar;
    public bool afetaHp, afetaMp;

    [Header("Detalhes Arma/Armaduras/Acessorio")]
    public int danoArma;
    public int defesaArmadura;
    public int resistenciaFogoArmadura;
    public int resistenciaGeloArmadura;
    public int resistenciaAcidoArmadura;
    public int resistenciaCortanteArmadura;
    public int resistenciaPerfuranteArmadura;
    public int resistenciaEsmagadorArmadura;
    public float criticoItem;

    [Header("Valores")]
    public int precoCompra;
    public int precoVenda;

    public void Use()
    {
        StatusPersonagem personagem = GameManager.instance.statusDoJogador;

        if (consumivel)
        {
            if (afetaHp)
            {
                personagem.hpAtual += quantidadeParaMudar;
                if(personagem.hpAtual > personagem.hpMaximo)
                {
                    personagem.hpAtual = personagem.hpMaximo;
                }
            }
            if (afetaMp)
            {
                personagem.mpAtual += quantidadeParaMudar;
                if (personagem.mpAtual > personagem.mpMaximo)
                {
                    personagem.mpAtual = personagem.mpMaximo;
                }
            }       
        }
        if (arma)
        {
            if (personagem.nomeMaoPrimaria != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeMaoPrimaria);
            }
            personagem.nomeMaoPrimaria = nomeDoItem;
            personagem.armaEquipadaPrimariaDano = danoArma;
            personagem.criticoArma = criticoItem;
        }
        if (armadura)
        {
            if (personagem.nomeArmadura != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeArmadura);
            }
            personagem.nomeArmadura = nomeDoItem;
            personagem.defesaArmadura = defesaArmadura;
            personagem.resistenciaAcidoArmadura = resistenciaAcidoArmadura;
            personagem.resistenciaFogoArmadura = resistenciaFogoArmadura;
            personagem.resistenciaGeloArmadura = resistenciaGeloArmadura;
            personagem.resistenciaCortanteArmadura = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteArmadura = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorArmadura = resistenciaEsmagadorArmadura;
        }
        if (colar)
        {
            if (personagem.nomeColar != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeColar);
            }
            personagem.nomeColar = nomeDoItem;
            personagem.defesaColar = defesaArmadura;
            personagem.criticoColar = criticoItem;
            personagem.resistenciaAcidoColar = resistenciaAcidoArmadura;
            personagem.resistenciaFogoColar = resistenciaFogoArmadura;
            personagem.resistenciaGeloColar = resistenciaGeloArmadura;
            personagem.resistenciaCortanteColar = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteColar = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorColar = resistenciaEsmagadorArmadura;
        }
        if (bota)
        {
            if (personagem.nomeBota != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeBota);
            }
            personagem.nomeBota = nomeDoItem;
            personagem.defesaBota = defesaArmadura;
            personagem.resistenciaAcidoBota = resistenciaAcidoArmadura;
            personagem.resistenciaFogoBota = resistenciaFogoArmadura;
            personagem.resistenciaGeloBota = resistenciaGeloArmadura;
            personagem.resistenciaCortanteBota = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteBota = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorBota = resistenciaEsmagadorArmadura;
        }
        if (luva)
        {
            if (personagem.nomeLuva != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeLuva);
            }
            personagem.nomeLuva = nomeDoItem;
            personagem.defesaLuva = defesaArmadura;
            personagem.criticoLuva = criticoItem;
            personagem.resistenciaAcidoLuva = resistenciaAcidoArmadura;
            personagem.resistenciaFogoLuva = resistenciaFogoArmadura;
            personagem.resistenciaGeloLuva = resistenciaGeloArmadura;
            personagem.resistenciaCortanteLuva = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteLuva = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorLuva = resistenciaEsmagadorArmadura;
        }
        if (elmo)
        {
            if (personagem.nomeElmo != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeElmo);
            }
            personagem.nomeElmo = nomeDoItem;
            personagem.defesaElmo = defesaArmadura;
            personagem.resistenciaAcidoElmo = resistenciaAcidoArmadura;
            personagem.resistenciaFogoElmo = resistenciaFogoArmadura;
            personagem.resistenciaGeloElmo = resistenciaGeloArmadura;
            personagem.resistenciaCortanteElmo = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteElmo = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorElmo = resistenciaEsmagadorArmadura;
        }
        if (berloque)
        {
            if (personagem.nomeBerloque != "")
            {
                GameManager.instance.AdicionaItem(personagem.nomeBerloque);
            }
            personagem.nomeBerloque = nomeDoItem;
            personagem.criticoBerloque = criticoItem;
            personagem.resistenciaAcidoBerloque = resistenciaAcidoArmadura;
            personagem.resistenciaFogoBerloque = resistenciaFogoArmadura;
            personagem.resistenciaGeloBerloque = resistenciaGeloArmadura;
            personagem.resistenciaCortanteBerloque = resistenciaCortanteArmadura;
            personagem.resistenciaPerfuranteBerloque = resistenciaPerfuranteArmadura;
            personagem.resistenciaEsmagadorBerloque = resistenciaEsmagadorArmadura;
        }

        GameManager.instance.RemoveItem(nomeDoItem);
        GameMenu.instance.TocaSomDoBotao();
    }

}
