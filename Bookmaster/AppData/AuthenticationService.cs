using Bookmaster.Model;

namespace Bookmaster.AppData
{
    static class AuthenticationService
    {
        public static Administrator? CurrentAdministrator { get; private set; }

        public static bool Authenticate(string username, string password)
        {
            CurrentAdministrator = App.context.Administrators.FirstOrDefault(administrator => administrator.Username == username && administrator.Password == password);

            if (CurrentAdministrator != null)
            {
                Feedback.Information("Администратор успешно авторизовался.");

                return true;
            }

            Feedback.Error("Пользователь не найден! Возможно вы ввели неправильно имя пользователя или пароль. Попробуйте снова.");

            return false;
        }

        public static void Logout()
        {
            CurrentAdministrator = null;
            Feedback.Information("Вы вышли из системы.");
        }
    }
}
