using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class AnchorPrefabSpawnerCustom : AnchorPrefabSpawner
{

    int index = 0;
    public override GameObject CustomPrefabSelection(MRUKAnchor anchor, List<GameObject> prefabs)
    {
        GameObject newPrefabs = prefabs[index];
        index++;
        return newPrefabs;
    }
}
