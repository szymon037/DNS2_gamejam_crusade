using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletPool
{
    public static Queue<GameObject> BasicBulletPool;
    private static GameObject BulletPrefab;

    static BulletPool() {
        var bulletsParent = new GameObject();
        bulletsParent.name = "Bullets";
        BulletPrefab = (Resources.Load(@"Prefabs/BulletPrefab") as GameObject);
        BasicBulletPool = new Queue<GameObject>(Constants.BULLET_POOL_SIZE);
        for (int i = 0; i < Constants.BULLET_POOL_SIZE; ++i) {
            GameObject obj = (Object.Instantiate(BulletPrefab, Vector3.zero, Quaternion.identity, bulletsParent.transform) as GameObject);
            Reclaim(obj);
        }
    }

    public static GameObject Get() {
        if (BasicBulletPool.Count <= 0) return null;
        return BasicBulletPool.Dequeue();
    }

    public static void Reclaim(GameObject obj) {
        BasicBulletPool.Enqueue(obj);
        obj.SetActive(false);
        obj.GetComponent<Bullet>().Clear();
    }

}
