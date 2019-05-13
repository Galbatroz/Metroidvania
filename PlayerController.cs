using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public bool podeAndar = true;
    public static PlayerController instance;
    
    void Awake(){
        instance = this;
    }

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void chamaMenu(){
        
    }
}
