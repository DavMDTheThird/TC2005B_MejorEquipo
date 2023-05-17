using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_basic{
    private short _hp;
    private short _lck;
    private short _atk;
    private short _spd;
    private short _stamina;
    private short _inventory;
    private short _money;

    public short HP{
        get{
            return _hp;
        }
        set{
            _hp = value;
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
    public short SPD{
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
    /// <param name="LUCK">Second value</param>
    /// <param name="Atack">Third value</param>
    /// <param name="Speed">Fourth value</param>
    /// <param name="Stamina">Fifth value</param>
    /// <param name="Inventory">Sixth value</param>
    /// <param name="Money">Seventh value</param>
    /// <returns> Crea un jugador base</returns>
    public Player_basic(short hp, short lck, short atk, short spd, short stamina, short inventory, short money){
        HP = hp;
        LCK = lck;
        ATK = atk;
        SPD = spd;
        Stamina = stamina;
        Inventory = inventory;
        Money = money;
    }


    public void Info(){
        Debug.Log("Health is " + HP);
        Debug.Log("Luck is " + LCK);
        Debug.Log("Atack is " + ATK);
        Debug.Log("Speed is " + SPD);
        Debug.Log("Stamina is " + Stamina);
        Debug.Log("Inventory Space is " + Inventory);
        Debug.Log("Money is " + Money);
    }
}
