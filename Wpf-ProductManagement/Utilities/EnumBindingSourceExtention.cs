using System.Windows.Markup;

namespace Wpf_ProductManagement.Utilities
{
    public class EnumBindingSourceExtention : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtention(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new ArgumentException("enumType must not be Enum and of type Enum.");
            this.EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
