using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour {

    #region Singleton

    private static System.Object lockObj = new object();
    private static SpawnManager instance;

    public static SpawnManager Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SpawnManager>();

                    //Debug Only
                    if (instance == null)
                    {
                        Debug.LogError("SpawnManager instance hasn`t found!");
                    }
                }
                return instance;
            }
        }
    }
    #endregion

    #region Constants
    private int[] BLINK_ARRAY = {4, 11, 18};
    #endregion

    private int tanksSpawned = 0;

    private void Start () {
		
	}
	
	private void Update () {
		
	}

    private void SpawnTank()
    {
        tanksSpawned++;

        if (CheckBlinking())
        {

        }

    }

    private bool CheckBlinking()
    {
        return Array.IndexOf(BLINK_ARRAY, tanksSpawned) >= 0;
    }

}
