﻿#pragma checksum "..\..\Admin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73ED0211799A6A1FA9A7A95BE910D5146F77EDD3B12F233A473D639F4A80C0E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Application;
using Application.MVVW.View;
using Application.MVVW.ViewModel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Application {
    
    
    /// <summary>
    /// Admin
    /// </summary>
    public partial class Admin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderMainMenu;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AppName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon CloseIcon;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon MinimIcon;
        
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
            System.Uri resourceLocater = new System.Uri("/Application;component/admin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Admin.xaml"
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
            this.borderMainMenu = ((System.Windows.Controls.Border)(target));
            
            #line 22 "..\..\Admin.xaml"
            this.borderMainMenu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.borderMainMenu_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AppName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 44 "..\..\Admin.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CloseIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            
            #line 54 "..\..\Admin.xaml"
            this.CloseIcon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseIcon_MouseDown);
            
            #line default
            #line hidden
            
            #line 54 "..\..\Admin.xaml"
            this.CloseIcon.MouseEnter += new System.Windows.Input.MouseEventHandler(this.CloseIcon_MouseEnter);
            
            #line default
            #line hidden
            
            #line 54 "..\..\Admin.xaml"
            this.CloseIcon.MouseLeave += new System.Windows.Input.MouseEventHandler(this.CloseIcon_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MinimIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            
            #line 58 "..\..\Admin.xaml"
            this.MinimIcon.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MinimIcon_MouseDown);
            
            #line default
            #line hidden
            
            #line 58 "..\..\Admin.xaml"
            this.MinimIcon.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MinimIcon_MouseEnter);
            
            #line default
            #line hidden
            
            #line 58 "..\..\Admin.xaml"
            this.MinimIcon.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MinimIcon_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
