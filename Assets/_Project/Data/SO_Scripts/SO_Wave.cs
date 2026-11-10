using System.Collections.Generic;
using UnityEngine;

namespace HordeProtocol.Data
{
    [CreateAssetMenu(fileName = "SO_Wave", menuName = "Enemy/Create New Wave")]
    public class SO_Wave : ScriptableObject
    {
        public int WaveCount;
        public List<SO_Enemy> Enemies;
    }
}
