using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;
    public StatusPersonagem statusDoJogador;
    public string[] itensEmPosse;
    public int[] quantidadeDeItens;
    public Item[] listaDeItens;
    
    public bool menuAtivo;
    
    void Awake(){
        instance = this;
    }

	void Start () {
        
        DontDestroyOnLoad(gameObject);

        OrganizaItem();
		
	}
	
	void Update () {
        
        if(menuAtivo == true){
            PlayerController.instance.podeAndar = false;
        }
        else
        {
            PlayerController.instance.podeAndar = true;
        }
		
	}
    public Item PegaDetalheDoItem(string itemParaPegar)
    {
        for(int i = 0; i < itensEmPosse.Length; i++)
        {
            if(listaDeItens[i].nomeDoItem == itemParaPegar)
            {
                return listaDeItens[i];
            }
        }
        return null;
    }

    public void AdicionaItem(string itemParaAdicionar)
    {
        int posicaoDoNovoItem = 0;
        bool encontrouEspaco = false;

        for(int i = 0; i < itensEmPosse.Length; i++)
        {
            if(itensEmPosse[i] == "" || itensEmPosse[i] == itemParaAdicionar)
            {
                posicaoDoNovoItem = i;
                i = itensEmPosse.Length;
                encontrouEspaco = true;
            }         
        }
        if (encontrouEspaco)
        {
            bool itemExiste = false;
            for (int i = 0; i < listaDeItens.Length; i++)
            {
                if(listaDeItens[i].nomeDoItem == itemParaAdicionar)
                {
                    itemExiste = true;
                    i = listaDeItens.Length;
                }
            }
            if (itemExiste)
            {
                itensEmPosse[posicaoDoNovoItem] = itemParaAdicionar;
                quantidadeDeItens[posicaoDoNovoItem]++;
            }
        }

        GameMenu.instance.MostraItens();
    } //Adiciona um item no Inventario.

    public void RemoveItem(string itemParaRemover)
    {
        bool itemEncontrado = false;
        int posicaoDoItem = 0;
        for(int i = 0; i < itensEmPosse.Length; i++)
        {
            if(itensEmPosse[i] == itemParaRemover)
            {
                itemEncontrado = true;
                posicaoDoItem = i;
                i = itensEmPosse.Length;
            }
        }
        if (itemEncontrado)
        {
            quantidadeDeItens[posicaoDoItem]--;
            if(quantidadeDeItens[posicaoDoItem] <= 0)
            {
                itensEmPosse[posicaoDoItem] = "";
            }
            GameMenu.instance.MostraItens();
        }
    } //Remove um item do Inventario.

    public void OrganizaItem()
    {
        bool itemDepoisDoEspaco = true;
        while (itemDepoisDoEspaco)
        {
            itemDepoisDoEspaco = false;
            for(int i = 0; i < itensEmPosse.Length - 1; i++)
            {
                if(itensEmPosse[i] == "")
                {
                    itensEmPosse[i] = itensEmPosse[i + 1];
                    itensEmPosse[i + 1] = "";
                    quantidadeDeItens[i] = quantidadeDeItens[i + 1];
                    quantidadeDeItens[i + 1] = 0;
                    if(itensEmPosse[i] != "")
                    {
                        itemDepoisDoEspaco = true;
                    }
                }
            }
        }
    } //Organiza os itens no Inventario.
}
