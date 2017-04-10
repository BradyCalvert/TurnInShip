using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CrewMember {

    public enum Style { Aggresive, Defensive, Evasive};

	public string crewName;
    public int def, str, agi, health;
    public Style fightStyle;
}
