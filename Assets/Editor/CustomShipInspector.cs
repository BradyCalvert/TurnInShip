using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Ship))]
public class CustomShipInspector : Editor {
  Ship ship;
  public Ship gunStyle;
  public int attack;
  public int armor;
  public int agility;
  public int health;
  public int selGridInt = 0;
  public string[] selStrings = new string[] { "Ship", "Crew" };
  public int defense;
  public string crewName;
  public CrewMember fightStyle;
  CrewMember crew;
  public void OnEnable()

  {
    ship = (Ship)target;
    
  }

  public override void OnInspectorGUI()
  {
    selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);
    if (selGridInt == 0)
    {
      APShip();
    }
    else if (selGridInt == 1)
    {
      APCrew();
    }
  } 

    private void APShip()
    {
    int pointsLeft = 100;
      int totalPoints = (ship.attack + ship.armor + ship.agility);
      totalPoints = EditorGUILayout.IntField((new GUIContent("Total Skill Points","Max is 100")), Mathf.Min(100, (ship.attack + ship.armor + ship.agility)));
      ship.attack = EditorGUILayout.IntField("Attack", Mathf.Max(ship.attack, 10));
    int newAttack = ship.attack;
      ship.agility = EditorGUILayout.IntField("Agility", Mathf.Max(ship.agility, 10));
    int newAgility = ship.agility;
      ship.armor = EditorGUILayout.IntField("Armor", Mathf.Max(ship.armor, 10));
    int newArmor = ship.armor;
    ship.hitPoints = EditorGUILayout.IntField("Hit Points", Mathf.Min(100,ship.hitPoints));
        ship.hitPoints = Mathf.Max(ship.hitPoints, 0);
    ship.armor = Mathf.Min(pointsLeft-(newAttack+newAgility), ship.armor);
      ship.attack = Mathf.Min(pointsLeft - (newArmor + newAgility), ship.attack);
      ship.agility = Mathf.Min(pointsLeft - (newArmor + newAttack), ship.agility);
    serializedObject.Update();
    GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
    myStyle.alignment = TextAnchor.MiddleCenter;
    SerializedProperty myGun = serializedObject.FindProperty("shipGuns");
    EditorGUILayout.PropertyField(myGun, true);
    serializedObject.ApplyModifiedProperties();
    }
    
        private void APCrew()
{
    serializedObject.Update();
    GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
    myStyle.alignment = TextAnchor.MiddleCenter;
    SerializedProperty myMember = serializedObject.FindProperty("crewMembers");

    EditorGUILayout.PropertyField(myMember, true);
    serializedObject.ApplyModifiedProperties();

    
  }
}

