﻿#pragma checksum "..\..\..\..\View\StopsPickPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ACF428E74DCEBD5F24FF8B4CB515878905A89BBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AllTrans.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AllTrans.View {
    
    
    /// <summary>
    /// StopsPickPage
    /// </summary>
    public partial class StopsPickPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\StopsPickPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TransSearch;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\View\StopsPickPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RouteList;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\View\StopsPickPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StopsList;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\View\StopsPickPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InfoGrid;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\View\StopsPickPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TimeList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AllTrans;V1.0.0.0;component/view/stopspickpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\StopsPickPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TransSearch = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.RouteList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\..\View\StopsPickPage.xaml"
            this.RouteList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionRouteEvent);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StopsList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.InfoGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.TimeList = ((System.Windows.Controls.ListView)(target));
            
            #line 79 "..\..\..\..\View\StopsPickPage.xaml"
            this.TimeList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PickEvent);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
