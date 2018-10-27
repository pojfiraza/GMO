using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlantObject : MonoBehaviour {
    public int dayz = 0;
    int delay = 0;
    private void Awake()
    {
        delay = ((this.growth - 1) % (growthStages.Length - 1));
        for(int x = 0; x<2; x++)
        {
            dna[x] = new bool[dnaSize];
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && growth > dayz + ((this.growth - 1) % (growthStages.Length - 1)))
        {
            Debug.Log(dayz);
            if(dayz / ((this.growth - 1) / (growthStages.Length - 1)) == growthStages.Length - 2 && delay!=0) 
            {
                delay -= 1;
                dayz -= 1;
            }
            else gameObject.GetComponent<SpriteRenderer>().sprite = growthStages[dayz / ((this.growth - 1) / (growthStages.Length - 1))];
        }else if (Input.GetKeyUp(KeyCode.E) && growth <= dayz+ ((this.growth - 1) % (growthStages.Length - 1)))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = growthStages[growthStages.Length - 1];
            Debug.Log("Dayz:" + dayz + " Growth: " + growth);
            isRipe = true;
        }
    }
    //Name of Plant
    [SerializeField] string pName;
    //Important Stats
    [SerializeField] int maxStat;
    [SerializeField] int dnaSize;
    [SerializeField] int growth;
    [SerializeField] int price;
    [SerializeField] int seeds;
    [SerializeField] int reGrow;
    bool isWatered = false;
    public bool isRipe = false;
    //Stats
    [SerializeField] int[] stats = {0,0,0,0,0};
    //Sprite Arr for its growth
    [SerializeField] Sprite[] growthStages;
    //StatNames
    private string[] statName = { "Nutrition:", "Yield:", "Disease Res:", "Cold Res:", "Heat Res:" };
    //Dna
    bool[][] dna = new bool[2][];

    //ID
    String id;
    //Type of Plant
    [SerializeField] String pType;

    //GetName
    string getName()
    {
        return this.name;
    }
    //GetStats
    int getStats(int location)
    {
        return this.stats[location];
    }
    //Verify if both Alleles are True
    bool isDnaTrue(int location)
    {
        if (this.dna[0][location] == this.dna[1][location] && this.dna[0][location] == true) return true;
        else return false;
    }
    // Set Stats Value
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
    //Create New Seeds for Market ( Seperated By Tier)
    PlantObject makePlants(int tier,PlantObject type)
    {
        PlantObject baby = type;
        int maxDNA = 0;
        int c = 0;
        System.Random rand = new System.Random();
        // DNA
        switch (tier)
        {
            case 1:
                maxDNA = dnaSize/4;
                break;
            case 2:
                maxDNA = dnaSize/ 2;
                break;
            case 3:
                maxDNA = dnaSize;
                break;
        }
        int mult = 1;
        while (maxDNA != 0)
        {
            bool check;
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < dnaSize; x++)
                {
                    check = false;
                    if (maxDNA == 0) break;
                    c = rand.Next(0,mult + 1);
                    maxDNA = maxDNA - c;
                    if (c == 1) check = true;
                    baby.dna[y][x] = check;
                }
            }
        }
        // Stats
        int randomDiff=0;
        switch (tier)
        {
            case 1:
                randomDiff = rand.Next(0,maxStat/20);
                break;
            case 2:
                randomDiff = rand.Next(maxStat / 20,maxStat /15);
                break;
            case 3:
                randomDiff = rand.Next(maxStat / 15, maxStat / 10);
                break;
        }

        mult = 3;
        // Create Stats
        while (randomDiff != 0)
        {
            for (int x = 0; x < 5; x++)
            {
                if (randomDiff < mult) mult = randomDiff;
                if (randomDiff == 0) break;
                c = rand.Next(0,mult + 1);
                randomDiff -=c;
                baby.stats[x] += c;
            }
        }
        //Price
        price = price + (baby.stats[0])/2;
        //Buffs
        baby = buffList(baby,pType);
        for (int s = 0; s < 5; s++)
        {
            // Negative Check
            if (baby.getStats(s) < 1) baby.setStats(s, 0);
        }
        //Create ID
        baby.id=idCreate(baby);
        //Return
        return baby;
    }
    //Bufflist of each Plant
    PlantObject buffList(PlantObject baby,String pType)
    {
        if(pType == "Bobtato")
        {
            for (int x = 1; x<6; x++)
            {
                int couchC = 0;
                if (baby.isDnaTrue(0))
                {
                    baby.price += 100;
                    baby.setStats(2,0);
                }
                if (baby.isDnaTrue(x) == baby.isDnaTrue(x+5) && baby.isDnaTrue(x) == true)
                {
                    baby.setStats(x-1, baby.getStats(x - 1) + 10);
                }
                else if (baby.isDnaTrue(x) == true)
                {
                    baby.setStats(x-1, baby.getStats(x - 1) + 5);
                    couchC += 1;
                }
                else if (baby.isDnaTrue(x+5) == true)
                {
                    baby.setStats(x-1, baby.getStats(x - 1) - 5);
                }
                if(baby.isDnaTrue(11) == true && baby.isDnaTrue(12) == true)
                {
                    baby.seeds = 0;
                }
                if(baby.isDnaTrue(13) == true)
                {
                    baby.setStats(0,baby.getStats(0)+5);
                    baby.growth += 1;
                }
                if (baby.isDnaTrue(14) == true && couchC>2)
                {
                    baby.growth += 2;
                }
            }

        }
        else if(pType == "Strawberry")
        {
            int countP = 0;
            for(int y = 1; y<6; y++)
            {
                if (baby.isDnaTrue(y) == true)
                {
                    baby.setStats(y, baby.getStats(y - 1) - 5);
                    countP += 1;
                }
            }
            if(countP>2 && baby.isDnaTrue(0) == true){
                baby.setStats(1,baby.getStats(1)*2);
            }
            if (countP > 2 && baby.isDnaTrue(0) == true)
            {
                baby.setStats(1, baby.getStats(1) * 2);
            }
            if(baby.isDnaTrue(6) == true)
            {
                if (baby.isDnaTrue(7) == true)
                {
                    if (baby.isDnaTrue(8) == true)
                    {
                        baby.price += 75;
                        baby.reGrow = 2;
                    }
                    else baby.price += 50;
                }
                else baby.price += 25;
            }

        }
        else if (pType == "Rockfruit")
        {
            if(baby.isDnaTrue(0) == true)
            {
                baby.stats[3] -= 10;
                baby.stats[4] -= 10;
                if (baby.isDnaTrue(2) == true)
                {
                    baby.price += baby.stats[3] + baby.stats[4]; 
                }
                if(baby.isDnaTrue(3) == true)
                {
                    baby.isWatered = true;
                }
            }
            if(baby.isDnaTrue(3) == baby.isDnaTrue(4) && baby.isDnaTrue(3) == true)
            {
                baby.seeds = 0;
            }


        }

        return baby;
    }
    //Create Unique Id for Plant
    String idCreate(PlantObject baby)
    {
        String id = "0";
        String cow = null;
        for (int x = 0; x<dnaSize; x++)
        {
            // If DNA is O O
            if (baby.isDnaTrue(x) == true)
            {
                cow += "1";
            }
            // If DNA is O X
            else if (baby.dna[0][x] == true) cow += "2";
            // If DNA is X O
            else cow += "0";
        }
        id = baby.pType + baby.stats[0].ToString()+ " " + baby.stats[1].ToString() + " " + baby.stats[2].ToString() + " " + baby.stats[3].ToString() + " " + baby.stats[4].ToString()+ " " + cow ;
        return id;
    }
    
}
