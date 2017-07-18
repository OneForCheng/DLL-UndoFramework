using  System;
using ForCheng.UndoFramework.Abstract;

namespace ForCheng.UndoFramework.Actions
{
    /// <summary>
    /// 互反操作
    /// </summary>
    public class CallMethodAction : AbstractBackableAction
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="execute">执行函数</param>
        /// <param name="unexecute">撤销执行的函数</param>
        public CallMethodAction(Action execute, Action unexecute)
        {
            ExecuteDelegate = execute;
            UnexecuteDelegate = unexecute;
        }

        /// <summary>
        /// 操作的委托
        /// </summary>
        public Action ExecuteDelegate { get; set; }

        /// <summary>
        /// 撤销操作的委托
        /// </summary>
        public Action UnexecuteDelegate { get; set; }

        /// <summary>
        /// 执行操作核心
        /// </summary>
        protected override void ExecuteCore()
        {
            ExecuteDelegate?.Invoke();
        }

        /// <summary>
        /// 执行撤销操作核心
        /// </summary>
        protected override void UnExecuteCore()
        {
            UnexecuteDelegate?.Invoke();
        }
    }

}
