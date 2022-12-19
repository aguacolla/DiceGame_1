using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class TileScript : MonoBehaviour
{
    public TilePlacement[] TilesPlacement;

    [Button]
    private void SetRefs()
    {
        TilesPlacement = GetComponentsInChildren<TilePlacement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
