using UnityEngine;

namespace Script
{
    public class EnemyState : MonoBehaviour
    {
        public int maxHp = 100;

        public int currentHp;
        // Start is called before the first frame update
        void Start()
        {
            currentHp = maxHp;
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            Debug.Log($"{gameObject.name} 挨打了！受到了 {damage} 点伤害。剩余血量: {currentHp}");
            if (currentHp <= 0) Die();
        }

        private void Die()
        {
            Debug.Log($"{gameObject.name} 死了！");
            Destroy(gameObject);
        }
    }
}
