using UnityEngine;

namespace SpaceMobile
{
    public class EnemyMoveSetSpawner : Spawner
    {
        [SerializeField] private EnemyMoveSet[] _MoveSets;

        public float SpawnDelay => spawnDelay;

        // �� ������ ������� ��� ����� ������� �� �����������!!!!
        // ������� ������ ���������� ������������ � ������

        protected override void Spawn()
        {
            if (startTimer <= startDelay)
            {
                startTimer += Time.deltaTime;
                return;
            }

            timeAfterLastSpawn += Time.deltaTime;

            if (timeAfterLastSpawn >= spawnDelay)
            {
                EnemyMoveSet moveSet = _MoveSets[Random.Range(0, _MoveSets.Length)];

                Instantiate(moveSet, transform.position, Quaternion.identity, transform);
                
                timeAfterLastSpawn = 0;
            }
        }
    }
}
