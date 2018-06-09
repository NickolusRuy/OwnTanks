using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    #region Singleton

    private static System.Object lockObj = new object();
    private static Pool instance;

    public static Pool Instance
    {
        get
        {
            lock(lockObj)
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<Pool>();

                    //Debug Only
                    if(instance == null)
                    {
                        Debug.LogError("Pool instance hasn`t found!");
                    }
                }
                return instance;
            }
        }
    }
    #endregion

    #region Constants
    private const int TANKS_COUNT = 20;
    private const int BULLETS_COUNT = 20;
    #endregion

    #region Spawn Objects
    [SerializeField]
    private Bullet bulletObject;
    #endregion

    #region Spawn lists
    private List<Bullet> bulletList = new List<Bullet>();
    #endregion

    [SerializeField]
    private Transform poolPoint;

    private void Start () {
        FillPool();
    }
	
	private void Update () {
		
	}

    private void FillPool()
    {
        for (int i = 0; i < BULLETS_COUNT; i++)
        {
            Bullet tmpBullet = Instantiate(bulletObject, poolPoint.position, Quaternion.identity);
            tmpBullet.InitComponents();
            tmpBullet.gameObject.SetActive(false);
            bulletList.Add(tmpBullet);
        }
    }

    public void AddBullet(Bullet tmp)
    {
        if (bulletList.IndexOf(tmp) < 0)
        {
            tmp.transform.position = poolPoint.position;
            tmp.gameObject.SetActive(false);
            bulletList.Add(tmp);
        }
    }

    public Bullet GetBullet()
    {
        int index = bulletList.Count - 1;

        Bullet tmp = bulletList[index];
        bulletList.RemoveAt(index);
        tmp.gameObject.SetActive(true);
        return tmp;
    }
}
