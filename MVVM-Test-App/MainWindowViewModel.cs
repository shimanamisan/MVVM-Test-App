using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Test_App
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        // プロパティの変更時に発火する
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _textBoxValue;

        public string? TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                // 現在の値と変更があった場合
                if (_textBoxValue != value)
                {
                    // 変更があった値をプロパティに代入
                    _textBoxValue = value;
                    // TextBoxValueプロパティに変更があったことを通知する
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// PropertyChangedEventArgsを発火させる
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
