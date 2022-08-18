using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixture 
{
    // Start is called before the first frame update
    public enum MixtureType
    {
        Strength,
        Levitation,
        Zadna
    }
    public Mixture(MixtureType typ)
    {
        this.mixtureType = typ;
    }
    public MixtureType mixtureType;
}
