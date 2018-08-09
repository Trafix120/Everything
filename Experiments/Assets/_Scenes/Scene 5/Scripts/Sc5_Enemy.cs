using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Entity")]
public class Sc5_Enemy : ScriptableObject { 
    public new string name;
    public int health;
    public int[] damage;
    public float[] range;
}


	
