using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;

using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;


namespace CustomParameterValidator
{
    public class CustomBehaviorSection : BehaviorExtensionElement
    {

        private const string EnabledAttributeName = "enabled";

        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        protected override object CreateBehavior()
        {
            return new ValidationBehavior(this.Enabled);

        }

        public override Type BehaviorType
        {

            get { return typeof(ValidationBehavior); }


        }
    }


}
