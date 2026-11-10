using UnityEngine;

namespace HordeProtocol.Data
{
    [CreateAssetMenu(fileName = "SO_Loot", menuName = "Loot/Create New Loot")]
    public class SO_Loot : ScriptableObject
    {
        public string lootName;
        public string lootDescription;
    }
}
