using System.Windows;

namespace Bookmaster.AppData
{
    /// <summary>
    /// Представляет класс для реализации обратной связи с пользователем.
    /// </summary>
    internal class Feedback
    {
        /// <summary>
        /// Отображает окно сообщения об ошибке с информацией из переданного исключения.
        /// </summary>
        /// <param name="exception">Исключение, информация из которого будет отображена в сообщении.</param>
        internal static void Error(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.HelpLink, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Отображает окно сообщения об ошибке с указанным текстом и заголовком.
        /// </summary>
        /// <param name="text">Текст сообщения об ошибке.</param>
        /// <param name="title">Заголовок окна сообщения. По умолчанию "Ошибка".</param>
        internal static void Error(string text, string title = "Ошибка")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Отображает информационное сообщение с указанным текстом и заголовком.
        /// </summary>
        /// <param name="text">Текст информационного сообщения.</param>
        /// <param name="title">Заголовок окна сообщения.</param>
        internal static void Information(string text, string title = "Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Отображает окно с вопросом и двумя кнопками "Да" и "Нет".
        /// </summary>
        /// <param name="text">Текст вопроса.</param>
        /// <param name="title">Заголовок окна. По умолчанию "Вопрос".</param>
        /// <returns>True, если пользователь нажал кнопку "Да". False, если нажата кнопка "Нет".</returns>
        internal static bool Question(string text, string title = "Вопрос")
        {
            return MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Отображает предупреждение с указанным текстом и заголовком.
        /// </summary>
        /// <param name="text">Текст предупреждения.</param>
        /// <param name="title">Заголовок окна предупреждения. По умолчанию "Предупреждение".</param>
        internal static void Warning(string text, string title = "Предупреждение")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
