﻿#pragma checksum "..\..\..\Views\dangnhap.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CF026149095129B05CEE8A9FF407F4E24FB0C5082A54AD0D5FF56F762D5FF89"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CTFproject;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CTFproject {
    
    
    /// <summary>
    /// dangnhap
    /// </summary>
    public partial class dangnhap : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Views\dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email_text;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Views\dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_text;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button login_bt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button forgot_bt;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\dangnhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button register_bt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CTFproject;component/views/dangnhap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\dangnhap.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.email_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.password_text = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.login_bt = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\dangnhap.xaml"
            this.login_bt.Click += new System.Windows.RoutedEventHandler(this.login_bt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.forgot_bt = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Views\dangnhap.xaml"
            this.forgot_bt.Click += new System.Windows.RoutedEventHandler(this.forgot_bt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.register_bt = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Views\dangnhap.xaml"
            this.register_bt.Click += new System.Windows.RoutedEventHandler(this.register_bt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

