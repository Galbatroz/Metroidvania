using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPersonagem : MonoBehaviour {

    //Status Primarios
    public string nomePersonagem;
    public int levelPersonagem = 1;
    public int levelMaximo = 100;
    public int expAtual;
    public int[] expProximoLevel;
    public int hpAtual;
    public int hpMaximo;
    public int mpAtual;
    public int mpMaximo;
    public int pontosDeMaestrie;
    public int forca = 5;
    public int intelecto = 3;
    public int vitalidade = 4;
    public int sorte = 3;  
    public int ataqueMaoPrimaria;
    public int ataqueMaoSecundaria;
    public Sprite foto;

    //Status Secundarios   
    public float resistenciaFogo;
    public float resistenciaGelo;
    public float resistenciaAcido;
    public float resistenciaCortante;
    public float resistenciaPerfurante;
    public float resistenciaEsmagador;

    //Status do Equipamentos
    public string nomeMaoPrimaria;
    public string nomeMaoSecundaria;
    public string nomeColar;
    public string nomeElmo;
    public string nomeArmadura;
    public string nomeBota;
    public string nomeLuva;
    public string nomeBerloque;
    public float resistenciaAcidoArmadura;
    public float resistenciaAcidoElmo;
    public float resistenciaAcidoBota;
    public float resistenciaAcidoLuva;
    public float resistenciaAcidoBerloque;
    public float resistenciaAcidoArmaPrincipal;
    public float resistenciaAcidoArmaSecundaria;
    public float resistenciaAcidoColar;
    public float resistenciaGeloArmadura;
    public float resistenciaGeloElmo;
    public float resistenciaGeloBota;
    public float resistenciaGeloLuva;
    public float resistenciaGeloBerloque;
    public float resistenciaGeloArmaPrincipal;
    public float resistenciaGeloArmaSecundaria;
    public float resistenciaGeloColar;
    public float resistenciaFogoArmadura;
    public float resistenciaFogoElmo;
    public float resistenciaFogoBota;
    public float resistenciaFogoLuva;
    public float resistenciaFogoBerloque;
    public float resistenciaFogoArmaPrincipal;
    public float resistenciaFogoArmaSecundaria;
    public float resistenciaFogoColar;
    public float resistenciaCortanteArmadura;
    public float resistenciaCortanteElmo;
    public float resistenciaCortanteBota;
    public float resistenciaCortanteLuva;
    public float resistenciaCortanteBerloque;
    public float resistenciaCortanteArmaPrincipal;
    public float resistenciaCortanteArmaSecundaria;
    public float resistenciaCortanteColar;
    public float resistenciaPerfuranteArmadura;
    public float resistenciaPerfuranteElmo;
    public float resistenciaPerfuranteBota;
    public float resistenciaPerfuranteLuva;
    public float resistenciaPerfuranteBerloque;
    public float resistenciaPerfuranteArmaPrincipal;
    public float resistenciaPerfuranteArmaSecundaria;
    public float resistenciaPerfuranteColar;
    public float resistenciaEsmagadorArmadura;
    public float resistenciaEsmagadorElmo;
    public float resistenciaEsmagadorBota;
    public float resistenciaEsmagadorLuva;
    public float resistenciaEsmagadorBerloque;
    public float resistenciaEsmagadorArmaPrincipal;
    public float resistenciaEsmagadorArmaSecundaria;
    public float resistenciaEsmagadorColar;
    public int defesaArmadura;
    public int defesaColar;
    public int defesaElmo;
    public int defesaLuva;
    public int defesaBota;
    public float criticoArma;
    public float criticoColar;
    public float criticoBerloque;
    public float criticoLuva;
    public int armaEquipadaPrimariaDano;
    public int armaEquipadaSecundariaDano;
    public int defesa;
    public float critico;

    void Start () {

        hpMaximo = 30 + Mathf.FloorToInt((vitalidade * 3f));
        mpMaximo = 10 + Mathf.FloorToInt((intelecto * 2.5f));
        hpAtual = hpMaximo;
        mpAtual = mpMaximo;

        expProximoLevel = new int[levelMaximo];
        expProximoLevel[1] = 1000;

        for(int i = 2; i < expProximoLevel.Length; i++)
        {
            expProximoLevel[i] = Mathf.FloorToInt(expProximoLevel[i - 1] * 1.05f);
        }
		
	}
	
	void Update () {

        if(hpAtual > hpMaximo)
        {
            hpAtual = hpMaximo;
        }
        if(mpAtual > mpMaximo)
        {
            mpAtual = mpMaximo;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            AdicionarExp(1000);
        }

        ataqueMaoPrimaria = Mathf.FloorToInt(forca * 1.5f) + armaEquipadaPrimariaDano;
        ataqueMaoSecundaria = Mathf.FloorToInt(forca * 1.5f) + armaEquipadaSecundariaDano;
        defesa = defesaArmadura + defesaBota + defesaColar + defesaElmo + defesaLuva + Mathf.FloorToInt(vitalidade / 2);
        critico = (sorte / 2) + (criticoArma + criticoBerloque + criticoColar + criticoLuva);

    }

    public void AdicionarExp(int expAdicional)
    {
        if (levelPersonagem >= levelMaximo)
        {
            expAtual = 0;
        }
        else
        {
            expAtual += expAdicional;
        }

        if(levelPersonagem < levelMaximo)
        {
            if(expAtual > expProximoLevel[levelPersonagem])
            {
                expAtual -= expProximoLevel[levelPersonagem];
                levelPersonagem++;
                pontosDeMaestrie++;
                //DECISÃO DE AUTO DISTRIBUIÇÃO DE STATUS.
                if(levelPersonagem % 2 == 0)
                {
                    forca++;
                    sorte++;
                }
                else
                {
                    intelecto++;
                    vitalidade++;
                }
                hpMaximo = 30 + Mathf.FloorToInt((vitalidade * 2.5f));
                mpMaximo = 10 + Mathf.FloorToInt((intelecto * 2.5f));
                hpAtual = hpMaximo;
                mpAtual = mpMaximo;
                //=======================================

                //Chamar animação de Level Up aqui.
            }
        }
    }
}
