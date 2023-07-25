using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class Morale : MonoBehaviour
{
    //each milestone gives the player new protester
    public int[] mileStones;
    private int moraleLevel;

    public float points;
    public float MoraleDecayPace;

    public Scrollbar moraleBar;

    private List<MoraleAffector> affectors;

    private void Awake()
    {
        affectors = new List<MoraleAffector>();
        moraleLevel = 0;
    }

    private void Update()
    {
        points = Mathf.Max(points - Time.deltaTime * MoraleDecayPace, 0);
        moraleBar.size = points / mileStones[moraleLevel];
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

        UpdateMorale(multiplicationResult);

        print("current affectors count: " + affectors.Count);

        affectors.Clear();
    }

    public void UpdateMorale(int screamScore)
    {
        points += screamScore;

        if (points > mileStones[moraleLevel])
        {
            //TODO: gather new protester
            //TODO: play protesting sound (whistle)
            print("spawn protestor");
            points = 0;
            moraleLevel++;
        }
    }
}