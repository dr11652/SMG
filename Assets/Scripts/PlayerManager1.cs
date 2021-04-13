using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager1 : MonoBehaviour
{
    #region Singleton

    public static PlayerManager1 instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
