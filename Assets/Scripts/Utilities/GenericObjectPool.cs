using CosmicCuration.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmicCuration.Enemy.EnemyPool;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> item = new PooledItem<T>();
            item.Item = CreateItem();
            item.isUsed = true;
            pooledItems.Add(item);
            return item.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("child class donnt have implementation of CreateItem()");
        }
        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;

        }
    }
}
