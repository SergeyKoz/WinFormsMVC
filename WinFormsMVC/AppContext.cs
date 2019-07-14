using System.Windows.Forms;

namespace WinFormsMVC
{
    public class AppContext : ApplicationContext
    {
        public AppContext()
        {
            Router.Run("user/index");
        }

        public void Exit()
        {
            Application.Exit();
        }
    }
}
