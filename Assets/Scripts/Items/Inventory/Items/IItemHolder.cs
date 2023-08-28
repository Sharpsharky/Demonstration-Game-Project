namespace DemonstrationGameProject.Items.Inventory.Items
{
	using ItemsSO;

	public interface IItemHolder
	{
		Item GetItem(bool disposeHolder);
	}
}