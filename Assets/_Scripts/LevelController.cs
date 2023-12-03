using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    List<GameObject> Ballons = new List<GameObject>();
    [SerializeField] private GameObject BallonContainer;
    
    public string nextLevel = "";

    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = BallonContainer.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            Ballons.Add(child.gameObject);
        }
        Ballons.Remove(BallonContainer);
    }

    // Update is called once per frame
    void Update()
    {
        if(Ballons.Count <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void ballonPickUp(GameObject GO)
    {
        Ballons.Remove(GO);
    }



}
