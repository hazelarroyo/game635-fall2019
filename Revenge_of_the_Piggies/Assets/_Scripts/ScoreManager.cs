using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public static int score = 0;

    public static ScoreManager instance = new ScoreManager();

    //making ScoreManager private makes it so that you cannot create a new 
    //instance of the class in another script

    private ScoreManager()
    {

    }

    //Note: This script is an example of a Singleton
}
