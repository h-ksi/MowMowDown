public interface IHealth
{
	void Init(float maxHP);
	void TakeDamage(float damage);
	void Recovery(float heal);
}
