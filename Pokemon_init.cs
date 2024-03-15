using System;
using System.Linq;
using UnityEngine;

public class Pokemon_init : MonoBehaviour
{
    [SerializeField] private string pkName = "Amphinobi";
    [SerializeField] private int baseLife = 100;
    private int currentLife = 100;
    [SerializeField] private int atk = 20;
    [SerializeField] private int def = 5;
    private int statsPoints = 1;
    [SerializeField] private float weight = 20.5f;
    [SerializeField] private enum types
    {
        Normal,
        Fire,
        Fighting,
        Water,
        Flying,
        Grass,
        Poison,
        Electric,
        Ground,
        Psychic,
        Rock,
        Ice,
        Bug,
        Dragon,
        Ghost,
        Dark,
        Steel,
        Fairy
    }

    [SerializeField] private types type = types.Normal;
    [SerializeField] private types[] weakness = new types[2];
    [SerializeField] private types[] resistances = new types[2];
    
    void Start()
    {
        currentLife = baseLife;
        Display_Name();
        Display_CurrentLife();
        Display_Attack();
        Display_Defense();
        Display_Stats();
        Display_Weight();
        Display_Type();
        Display_Weakness();
        Display_Resistances();
        TakeDamage(10, type);
    }

    void Update(){
        CheckIfPokemonAlive();
    }


    private void Display_Name(){
        Debug.Log("Name : " + pkName);
    }

    private void Display_CurrentLife(){
        Debug.Log("Current Life of " + pkName + " is " + currentLife);
    }

    private void Display_Attack(){
        Debug.Log("Attack of " + pkName + " is " + atk);
    }

    private void Display_Defense(){
        Debug.Log("Defense of " + pkName + " is " + def);
    }

    private void Display_Stats(){
        Debug.Log("Stats of "  + pkName + " are " + InitStatsPoints());
    }

    private void Display_Weight(){
        Debug.Log("Weight of " + pkName + " is " + weight);
    }

    private void Display_Type(){
        Debug.Log("Type of " + pkName + " is " + type);
    }

    private void Display_Weakness(){
        foreach (types Type in weakness)
        {
            Debug.Log(pkName+ " is weak against " + Type);
        }
    }

    private void Display_Resistances(){
        foreach (types Type in resistances)
        {
            Debug.Log(pkName+ " is durable against " + Type);
        }
    }

    private int InitStatsPoints(){
        statsPoints = baseLife + atk + def;
        return statsPoints;
    }

    private int  GetAttackDamage(){
        return atk;
    }

    private void TakeDamage(int attack, types ennemyType){
        if (currentLife > 0){
            if (weakness.Contains(ennemyType)){
                attack *= 2;
            }
            if (resistances.Contains(ennemyType)){
                attack /= 2;
            }
            if (attack <= 0){
                Debug.Log("The attack had no effect");
                return;
            }
            currentLife -= attack;
            Debug.Log("The attack did " + attack + " damage, " + pkName + " has " + currentLife + " hps");
        }
    }

    private void CheckIfPokemonAlive(){
        if (currentLife > 0){
            Debug.Log(pkName + " is still alive");
        }
    }
}
