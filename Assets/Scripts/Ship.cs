using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public enum GunStyle { cannon, plasma, machinegun, flamethrower};


    /*
     * Armor, attack and agility all share a pool of 100 points.
     * Each stat cant go below 10. So Atk = 10, Arm = 10, Agi = 10,
     * The rest of the point (70). Can be divided out.
     * Make sure they never exceed a total of 100 points.
     * The user can use less than the 100, just make sure they cant below the 10 for each.
     */
    public int armor, attack, agility;
    public int hitPoints;
    public GunStyle[] shipGuns;
    public CrewMember[] crewMembers;

}
