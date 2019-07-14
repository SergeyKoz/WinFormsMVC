using System.Windows.Forms;
using WinFormsMVC.models;

namespace WinFormsMVC.controllers
{
    [Route(Route = "user")]
    class UserController: Controller
    {
        public void IndexAction()
        {
            if (!User.GetInstance().Logged) {
                (Application.OpenForms["LoginForm"] == null ? new LoginForm() : (LoginForm)Application.OpenForms["LoginForm"]).Show();
            } else {
                Router.Run("catalog/products/index");
            }
        }

        public void LoginAction(UserLoginParameters loginParameters)
        {
            User user = User.GetInstance();
            if (user.Login == loginParameters.Login && user.Password == loginParameters.Password)
            {
                user.Logged = true;                
                Application.OpenForms["LoginForm"].Hide();
                Router.Run("catalog/products/index");
            }           
        }

        public void LogoutAction()
        {
            User user = User.GetInstance();
            user.Logged = false;
            IndexAction();
        }
    }
}
