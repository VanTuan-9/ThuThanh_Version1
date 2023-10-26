public interface ICharacter {
    void Attack();
    void BeAttacked(int attackNumber);
    void Run();
    void Die();
    void UseSkill(SkillType skillType);
    void RotateCharacter(); 
    void BuffIndex();
}