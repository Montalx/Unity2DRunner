using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DestroyAll : MonoBehaviour
{

    public void UnloadScene()
    {
        Destroy(GameObject.Find("HUD"));
    }

}
