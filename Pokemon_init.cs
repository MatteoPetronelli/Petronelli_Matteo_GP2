using System;
using System.Linq;
using UnityEngine;

public class Pokemon_init : MonoBehaviour
{
    // declaration of variable the ones with [SerializeField] will be visibles in the inspector
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
    
    // When the script is played current Life will be initialized, then the pokemon data will be shown in the console and the pokeemon will receive an attack
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

    // play every frame the fuction for checking if the pokemon is alive
    void Update(){
        CheckIfPokemonAlive();
    }

    // Display functions for displaying pokemon data in the console
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

    // Initialisation of stats points
    private int InitStatsPoints(){
        statsPoints = baseLife + atk + def;
        return statsPoints;
    }

    // get the attack value of the pokemon
    private int  GetAttackDamage(){
        return atk;
    }

    // fuction for when the pokemon takes damages
    private void TakeDamage(int attack, types ennemyType){
        // the value of the current life of the pokemon must be greather than 0
        if (currentLife > 0){
            // the "if" and the two "else if" verify if the pokemon is weak, resistant or immune to the attack
            if (weakness.Contains(ennemyType)){
                attack *= 2;
            }
            else if (resistances.Contains(ennemyType)){
                attack /= 2;
            }
            else if (attack <= 0){
                Debug.Log("The attack had no effect");
                return;
            }
            currentLife -= attack;
            Debug.Log("The attack did " + attack + " damage, " + pkName + " has " + currentLife + " hps");
        }
    }

    // function that check if the pokemon is alive or dead 
    private void CheckIfPokemonAlive(){
        if (currentLife > 0){
            Debug.Log(pkName + " is still alive");
        }
        else {
            Debug.Log(pkName + " is dead");
        }
    }
}
