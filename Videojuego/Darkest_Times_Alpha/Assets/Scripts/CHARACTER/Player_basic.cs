using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esto no tenia el MonoBehaviour
public class Player_basic
{
    private int _hp;
    private int _maxhp;
    private int _lvl;
    private int _xp;
    private float _lck;
    private int _atk;
    private int _stamina;
    private int _inventory;
    private float _TimesMoney;
    private int _money;

    //Modificadores Get y Set de los stats del personaje
    public int HP{
        get{
            return _hp;
        }
        set{
            _hp = value;
        }
    }
    public int MAXHP{
        get{
            return _maxhp;
        }
        set{
            _maxhp = value;
        }
    }
    public int LVL{
        get{
            return _lvl;
        }
        set{
            _lvl = value;
        }
    }
    public int XP{
        get{
            return _xp;
        }
        set{
            _xp = value;
        }
    }
    public float LCK
    {
        get{
            return _lck;
        }
        set{
            _lck = value;
        }
    }
    public int ATK{
        get{
            return _atk;
        }
        set{
            _atk = value;
        }
    }
    public int Stamina{
        get{
            return _stamina;
        }
        set{
            _stamina = value;
        }
    }
    public int Inventory{
        get{
            return _inventory;
        }
        set{
            _inventory = value;
        }
    }
    public float TimesMoney
    {
        get
        {
            return _TimesMoney;
        }
        set
        {
            _TimesMoney = value;
        }
    }
    public int Money{
        get{
            return _money;
        }
        set{
            _money = value;
        }
    }

    /// <summary>
    /// Constructor de jugador basico.
    /// </summary>
    /// <param name="HP">First value</param>
    /// <param name="MAXHP">First value</param>
    /// <param name="Level">First value</param>
    /// <param name="xp">First value</param>
    /// <param name="Luck">Second value</param>
    /// <param name="Attack">Third value</param>
    /// <param name="Stamina">Fifth value</param>
    /// <param name="Inventory">Sixth value</param>
    /// <param name="Money">Seventh value</param>
    /// <returns> Crea un jugador base</returns>
    public Player_basic(int hp, int maxhp, int lvl, int xp, float lck, int atk, int stamina, int inventory, float timesMoney, int money){
        HP = hp;
        MAXHP = maxhp;
        LVL = lvl;
        XP = xp;
        LCK = lck;
        ATK = atk;
        Stamina = stamina;
        Inventory = inventory;
        TimesMoney = timesMoney;
        Money = money;
    }

    public Player_basic()
    {
        HP = 0;
        MAXHP = 0;
        LVL = 0;
        XP = 0;
        LCK = 0;
        ATK = 0;
        Stamina = 0;
        Inventory = 0;
        TimesMoney = 0;
        Money = 0;
    }

    public void Info(){
        Debug.Log("Health is " + HP + " out of " + MAXHP + "\n" +
                  "Current level: " + LVL + " next level at " + XP + " xp\n" +
                  "Luck is " + LCK + "\n" +
                  "Attack is " + ATK + "\n" +
                  "Stamina is " + Stamina + "\n" +
                  "Inventory Space is " + Inventory + "\n" +
                  "Money is " + Money + " increased by: " + TimesMoney +"\n");
    }

}
