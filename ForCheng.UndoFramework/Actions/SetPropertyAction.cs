using System.Reflection;
using ForCheng.UndoFramework.Abstract;

namespace ForCheng.UndoFramework.Actions
{
    /// <summary>
    /// 设置类属性操作
    /// </summary>
    public class SetPropertyAction : AbstractBackableAction
    {
        /// <summary>
        /// 设置对象的属性值
        /// </summary>
        /// <param name="parentObject"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public SetPropertyAction(object parentObject, string propertyName, object value)
        {
            ParentObject = parentObject;
            Property = parentObject.GetType().GetTypeInfo().GetDeclaredProperty(propertyName);
            Value = value;
        }

        /// <summary>
        /// 对象
        /// </summary>
        public object ParentObject { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 原值
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// 执行操作
        /// </summary>
        protected override void ExecuteCore()
        {
            OldValue = Property.GetValue(ParentObject, null);
            Property.SetValue(ParentObject, Value, null);
        }

        /// <summary>
        /// 撤销操作
        /// </summary>
        protected override void UnExecuteCore()
        {
            Property.SetValue(ParentObject, OldValue, null);
        }
    }
}
