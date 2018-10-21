using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantObject : MonoBehaviour {
    //Name of Plant
    public string pName;
    //StatNames
    public string[] statName = { "MaxStat","Growth", "ColdR", "HeatR", "Yield", "Nutri","Price","DnaSize"};
    //Stats
    public int[] stats = {0,0,0,0,0,0,0,0};
    //Dna
    public bool[][] dna;
    //Active Buffs|Debuffs
    Action[] buffers = null;
    //Sprite Arr for its growth
    Sprite[] growthStages;
    
  
    string getData()
    {
        return this.name;
    }
    int getStats(int location)
    {
        return this.stats[location];
    }
    bool[][] getDna()
    {
        return this.dna;
    }
    Action[] getBuffers()
    {
        return this.buffers;
    }
    void setStats(int location,int value)
    {
        stats[location] = value; 
    }
    // Change DNA value
    void setDNA(int row,int column,bool value)
    {
        dna[row][column] = value;
    }
    //Change DNA Size
    void setDNA(int size)
    {
        dna = new bool[size][];
        for(int x = 0; x<size;x++)
        {
            dna[x] =  new bool[2];
        }
    }
    //Change Buffer Size
    void setBuffer(int size)
    {
        buffers = new Action[size];
    }
    //Create Items for Shop
    PlantObject makePlants(int tier,PlantObject type)
    {
        PlantObject baby = new PlantObject();
        int maxDNA = 0;
        int c = 0;
        System.Random rand = new System.Random();

        // Aesthetic
        //baby.setStats(0, Random.Range(0, 4));
        //baby.setStats(1, Random.Range(0, 4));

        // DNA
        switch (tier)
        {
            case 1:
                maxDNA = baby.stats[7]/4;
                break;
            case 2:
                maxDNA = baby.stats[7] / 2;
                break;
            case 3:
                maxDNA = (3* baby.stats[7]) /4;
                break;
        }
        int mult = 1;
        while (maxDNA != 0)
        {
            bool check;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < baby.stats[7]; x++)
                {
                    check = false;
                    if (maxDNA == 0) break;
                    c = rand.Next(0,mult + 1);
                    maxDNA = maxDNA - c;
                    if (c == 1) check = true;
                    baby.dna[x][y] = check;
                }
            }
        }
        //Buffs
        //baby = buffGiver(baby);
        // Stats      
        switch (tier)
        {
            case 1:
                baby.setStats(0, baby.getStats(0)+ rand.Next(15,20));
                break;
            case 2:
                baby.setStats(0, baby.getStats(0) + rand.Next(35, 50));
                break;
            case 3:
                baby.setStats(0, baby.getStats(0) + rand.Next(55, 80));
                break;
        }
        // Negative Check
        if (baby.getStats(0) < 1) baby.setStats(0,1);
        mult = 3;
        while (baby.stats[0] != 0)
        {
            for (int x = 1; x < 6; x++)
            {
                if (baby.getStats(0) < mult) mult = baby.getStats(0);
                if (baby.getStats(0) == 0) break;
                c = rand.Next(0,mult + 1);
                baby.setStats(0,baby.getStats(0)-c);
                baby.stats[x] += c;
            }
        }
        //Price
        baby.stats[6] = 50 + (baby.stats[5] * 3) + ((baby.stats[2] + baby.stats[3]) * 2);
        //Return
        return baby;
    }
    public void buffGiver()
    {
        
    }
}
