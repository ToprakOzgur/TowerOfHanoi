
using System.Collections.Generic;

public class Pin
{
    public List<Ring> rings = new List<Ring>();
    public int maxRingCount;
    public bool isStartingPin;

    public Pin(int maxRingCount, bool isStartingPin) //I made ring count changable.
    {
        this.maxRingCount = maxRingCount;
        this.isStartingPin = isStartingPin;

        if (isStartingPin)
        {
            for (int i = 0; i < maxRingCount; i++) //inits rings at startting pin
            {
                rings.Add(new Ring(maxRingCount - i)); //first ring is bigger
            }
        }
    }


}
