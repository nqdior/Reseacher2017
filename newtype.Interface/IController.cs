using newtype.Controls;

namespace newtype.Interface
{
    public interface IController
    {
        ISqlManager sqlManager { get; set; }

        FormBar FormBar { get; set; }

        MenuBar MenuBar { get; set; }

        TabGridControl TabGrid { get; set; }

        string RecCount { set; }

        void SetAndExecuteSql(string sql = "");

        void UpdateDataBaseComboItems();
    }
}