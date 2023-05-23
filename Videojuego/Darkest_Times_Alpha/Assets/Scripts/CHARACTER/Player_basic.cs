using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Esto no tenia el MonoBehaviour
public class Player_basic
{
    private short _hp;
    private short _maxhp;
    private short _lvl;
    private short _xp;
    private short _lck;
    private short _atk;
    private float _spd;
    private short _stamina;
    private short _inventory;
    private short _money;

    //Modificadores Get y Set de los stats del personaje
    public short HP{
        get{
            return _hp;
        }
        set{
            _hp = value;
        }
    }
    public short MAXHP{
        get{
            return _maxhp;
        }
        set{
            _maxhp = value;
        }
    }
    public short LVL{
        get{
            return _lvl;
        }
        set{
            _lvl = value;
        }
    }
    public short XP{
        get{
            return _xp;
        }
        set{
            _xp = value;
        }
    }
    public short LCK{
        get{
            return _lck;
        }
        set{
            _lck = value;
        }
    }
    public short ATK{
        get{
            return _atk;
        }
        set{
            _atk = value;
        }
    }
    public float SPD{
        get{
            return _spd;
        }
        set{
            _spd = value;
        }
    }
    public short Stamina{
        get{
            return _stamina;
        }
        set{
            _stamina = value;
        }
    }
    public short Inventory{
        get{
            return _inventory;
        }
        set{
            _inventory = value;
        }
    }
    public short Money{
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
    /// <param name="Speed">Fourth value</param>
    /// <param name="Stamina">Fifth value</param>
    /// <param name="Inventory">Sixth value</param>
    /// <param name="Money">Seventh value</param>
    /// <returns> Crea un jugador base</returns>
    public Player_basic(short hp, short maxhp, short lvl, short xp, short lck, short atk, float spd, short stamina, short inventory, short money){
        HP = hp;
        MAXHP = maxhp;
        LVL = lvl;
        XP = xp;
        LCK = lck;
        ATK = atk;
        SPD = spd;
        Stamina = stamina;
        Inventory = inventory;
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
        SPD = 0;
        Stamina = 0;
        Inventory = 0;
        Money = 0;
    }

    public void Info(){
        Debug.Log("Health is " + HP + " out of " + MAXHP + "\n" +
                  "Current level: " + LVL + " next level at " + XP + " xp\n" +
                  "Luck is " + LCK + "\n" +
                  "Attack is " + ATK + "\n" +
                  "Speed is " + SPD + "\n" +
                  "Stamina is " + Stamina + "\n" +
                  "Inventory Space is " + Inventory + "\n" +
                  "Money is " + Money);
    }

}
