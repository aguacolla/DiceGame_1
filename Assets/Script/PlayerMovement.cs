using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    public TileScript _ts;
    public TilePlacement _tsSaved;
    public int NumberOfJumps;
    public int CurrentIndex;
    public float Speed;
    [Button]
  public void GoToDestination()
    {
        StartCoroutine(Jump());
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //1st green = 1
   public  IEnumerator Jump()
    {
        int curJump = 0;
        while (curJump + 1 <= NumberOfJumps)
        {
            yield return new WaitForSeconds(0.5f);
            CurrentIndex++;
            if (CurrentIndex >= _ts.TilesPlacement.Length)
            {
                CurrentIndex = 0;
            }
            curJump++;
            while (transform.position != _ts.TilesPlacement[CurrentIndex].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _ts.TilesPlacement[CurrentIndex].transform.position, Speed * Time.deltaTime);
                
                yield return null;
            }
        }
    

    }
    void SavePos(int SavePos)
    {
        _tsSaved = _ts.TilesPlacement[SavePos-1];
    }
}
