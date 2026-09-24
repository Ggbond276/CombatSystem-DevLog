using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    [System.Serializable]
    public class SkillData
    {
        public string skillName;
        public KeyCode castKey;
        public float range;
        public int damage;
        public Color gizmoColor = Color.red;
    }
    
    public class PlayerCombat : MonoBehaviour
    {

        [Header("技能配置 (模拟 Excel 表格)")]
        public List<SkillData> skillTable = new List<SkillData>();

        // Update is called once per frame
        void Update()
        {
            
            foreach (var skillData in skillTable)
            {
                if (Input.GetKeyDown(skillData.castKey))
                {
                    ExecuteAttack(skillData);
                }
            }
        }

        private void ExecuteAttack(SkillData skillData)
        {
            Debug.Log($"<color=cyan>释放技能：{skillData.skillName}</color> | 范围: {skillData.range} | 伤害: {skillData.damage}");
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, skillData.range);
            
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    EnemyState enemyState = hitCollider.GetComponent<EnemyState>();
                    if (enemyState != null)
                    {
                        enemyState.TakeDamage(skillData.damage);

                        float realDistance = Vector3.Distance(transform.position, hitCollider.transform.position);
                        Debug.Log("击中了：" + hitCollider.name + "，实际距离：" + realDistance);
                    }
                }
            }
        }
        
        
        // 【开发者神技】：在编辑器里可视化你的“雷达范围”
        // 只有在 Scene 窗口选中 Player 时，才会画出一个红色的线框球，代表你的真实攻击范围！
        void OnDrawGizmosSelected()
        {
            foreach (SkillData skill in skillTable)
            {
                Gizmos.color = skill.gizmoColor;
                Gizmos.DrawWireSphere(transform.position, skill.range);
            }
        }
    }
}
