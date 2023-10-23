public interface ICharacter {
    void Attack();
    void BeAttacked();
    void Run();
    void Die();
    void UseSkill(SkillType skillType);
    void RotatePlayer();
    
    void BuffIndex();
}