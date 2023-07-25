using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Morale : MonoBehaviour
{
    public int points;

    private List<MoraleAffector> affectors;

    private void Awake()
    {
        affectors = new List<MoraleAffector>();
    }

    public void AddAffector(MoraleAffector affector)
    {
        affectors.Add(affector);
    }

    public void RemoveAffector(MoraleAffector affector)
    {
        affectors.Remove(affector);
    }

    private int GetAffectorPoints(MoraleAffector affector)
    {
        switch (affector.affectorType)
        {
            case AffectorType.policeman:
                return 2;

            case AffectorType.cavalary:
                return 3;

            case AffectorType.waterCannon:
                return 7;

            default: return 0;
        }
    }

    public void Scream()
    {
        var pointList = affectors.Select(affector => GetAffectorPoints(affector));

        //multiplying all points together
        int multiplicationResult = 1;

        foreach (int point in pointList)
            multiplicationResult *= point;

        points += multiplicationResult;

        print("current affectors count: " + affectors.Count);

        affectors.Clear();
    }
}
