using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour{

    Player_basic Socrates;
    Player_basic Sisyphus;

    void Start(){

        Socrates = new Player_basic(100, 50, 10, 10, 100, 6, 73);
        // Sisyphus = new Player_basic(100, 50, 10, 10, 100, 6, 73);
        // Sisyphus.HP = 50;

        Socrates.Info();
        // Sisyphus.Info();




    }

}
