using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    #region Singleton

    public static ObjectsManager instance;


    void Awake (){
        instance = this;
    }

    #endregion

    public GameObject obstruction1;
    public GameObject obstruction2;

}
