﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OsteoYoga.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ModelResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ModelResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OsteoYoga.Resource.ModelResource", typeof(ModelResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nom/Prénom.
        /// </summary>
        public static string FullName {
            get {
                return ResourceManager.GetString("FullName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le nom/prénom est obligatoire.
        /// </summary>
        public static string FullNameMandatory {
            get {
                return ResourceManager.GetString("FullNameMandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Mail.
        /// </summary>
        public static string Mail {
            get {
                return ResourceManager.GetString("Mail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre E-Mail n&apos;est pas correct.
        /// </summary>
        public static string MailFormattingError {
            get {
                return ResourceManager.GetString("MailFormattingError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to L&apos; E-Mail est obligatoire.
        /// </summary>
        public static string MailMandatory {
            get {
                return ResourceManager.GetString("MailMandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Téléphone.
        /// </summary>
        public static string Phone {
            get {
                return ResourceManager.GetString("Phone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le numéro de téléphone est obligatoire (En cas d&apos;imprévus).
        /// </summary>
        public static string PhoneMandatory {
            get {
                return ResourceManager.GetString("PhoneMandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre nom/prénom.
        /// </summary>
        public static string YourFullName {
            get {
                return ResourceManager.GetString("YourFullName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre E-Mail.
        /// </summary>
        public static string YourMail {
            get {
                return ResourceManager.GetString("YourMail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre mot de passe.
        /// </summary>
        public static string YourPassword {
            get {
                return ResourceManager.GetString("YourPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Votre numéro de téléphone.
        /// </summary>
        public static string YourPhone {
            get {
                return ResourceManager.GetString("YourPhone", resourceCulture);
            }
        }
    }
}
