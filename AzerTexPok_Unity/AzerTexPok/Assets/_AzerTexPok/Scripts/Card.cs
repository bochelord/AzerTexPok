using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public enum Value { two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace };
public enum Color { hearts, diamonds, spades, clubs }

[Serializable]
public class Card : IComparable
{



    public Value cardValue;
    public Color cardColor;

    /// <summary>
    /// Icomparable interface
    /// </summary>
    /// <param name="obj">object to compare</param>
    /// <returns>-1 < obj, 0 = obj, 1 > obj </returns>
    public int CompareTo(object obj)
    {
        
        if (obj is Card)
        {
            return this.cardValue.CompareTo((obj as Card).cardValue);
        }
        else
        {
            throw new ArgumentException("Object to compare is not a Card");
        }



    }

    
}
