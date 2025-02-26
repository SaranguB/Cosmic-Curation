using CosmicCuration.Utilities;
using CosmicCuration.VFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        VFXView prefabToSpawn;

        public VFXPool(VFXView prefabToSpawn)
        {
            this.prefabToSpawn = prefabToSpawn;
        }

        public VFXController GetVFX()
        {
            return GetItem<VFXController>();
        }

        protected override VFXController CreateItem<T>() => new VFXController(prefabToSpawn);

    }
}

