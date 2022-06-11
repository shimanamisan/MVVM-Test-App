using System;
using System.Windows.Input;

namespace MVVM_Test_App
{
    internal class DelegateCommand<T> : ICommand
    {
        /// <summary>
        /// コマンドを実行するためのメソッドを保持する
        /// </summary>
        private readonly Action<T> _execute;

        /// <summary>
        /// コマンドが実行可能か判定するためのメソッドを保持する
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// コンストラクター。新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンドを実行するためのメソッドを指定する</param>
        public DelegateCommand(Action<T> execute) : this(execute, () => true) { }

        /// <summary>
        /// コンストラクター。新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンドを実行するためのメソッドを指定する</param>
        /// <param name="canExecute">コマンドの実行可能性を判別するためのメソッドを指定します。</param>
        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// コマンドが実行可能か状態が変化したら発火する
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            // RequerySuggested： コマンドを実行できるかどうかを変更する可能性のある条件が、
            //                    CommandManagerによって検出された場合に発生する
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// コマンドが実行可能か判別します。
        /// </summary>
        /// <param name="parameter">この処理に対するパラメータを指定する</param>
        /// <returns>コマンドが実行可能である場合にtrueを返す</returns>
        public bool CanExecute(object? parameter)
        {
            return this._canExecute();
        }

        /// <summary>
        /// コマンドを実行する
        /// </summary>
        /// <param name="parameter">この処理に対するパラメータを指定する</param>
        public void Execute(object? parameter)
        {
            this._execute((T)parameter);
        }
    }
}
