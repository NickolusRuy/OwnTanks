using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton

    private static System.Object lockObj = new object();
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();

                    //Debug Only
                    if (instance == null)
                    {
                        Debug.LogError("GameManager instance hasn`t found!");
                    }
                }
                return instance;
            }
        }
    }
    #endregion

    #region Constants
    public const string BULLET_TAG = "Bullet";
    public const string BONUS_TAG = "Bonus";
    public const string ENEMY_TAG = "Enemy";
    public const string PLAYER_TAG = "Player";
    public const string CONCRETE_TAG = "Concrete";
    public const string BRICKS_TAG = "Bricks";
    public const string WATER_TAG = "Water";
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
