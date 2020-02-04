using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Extension
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo _cultureInfo;
        public string Text
        {
            get;
            set;
        }

        private static readonly Lazy<ResourceManager>
            _resourceManager = new Lazy<ResourceManager>(() => new ResourceManager("ExpensesApp.Resources.Resources", IntrospectionExtensions.GetTypeInfo(typeof(Resources.Resources)).Assembly));

        public TranslateExtension()
        {
            _cultureInfo = CultureInfo.CurrentCulture;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return string.Empty;
            }
            var translate = _resourceManager.Value.GetString(Text, _cultureInfo);
            if (translate == null) 
            {
                return string.Empty;
            }

            return translate;
        }
    }
}
