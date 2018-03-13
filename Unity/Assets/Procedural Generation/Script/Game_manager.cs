using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To put on a game object 
public class Game_manager : MonoBehaviour {
    public BoardManager baord;
    public static Game_manager gm = null;
    public int lvl = 3; //maybe not usefull
	// Use this for initialization
	void gogogo () {
        baord = GetComponent<BoardManager>();
        Initgame();
	}
	
	// Update is called once per frame
	void Initgame () {
        baord.Sscene(lvl);

    }
}
