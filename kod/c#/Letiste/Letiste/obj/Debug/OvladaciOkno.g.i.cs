﻿#pragma checksum "..\..\OvladaciOkno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "944C1BDF3249641B95FF955631BCFC63379DA27B7D543467FDE1912985456C1F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using Letiste;
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


namespace Letiste {
    
    
    /// <summary>
    /// OvladaciOkno
    /// </summary>
    public partial class OvladaciOkno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ter;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button adm;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dom;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ahojda;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pr_let;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\OvladaciOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pr_pas;
        
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
            System.Uri resourceLocater = new System.Uri("/Letiste;component/ovladaciokno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OvladaciOkno.xaml"
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
            this.ter = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\OvladaciOkno.xaml"
            this.ter.Click += new System.Windows.RoutedEventHandler(this.Ter_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.adm = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\OvladaciOkno.xaml"
            this.adm.Click += new System.Windows.RoutedEventHandler(this.Adm_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dom = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\OvladaciOkno.xaml"
            this.dom.Click += new System.Windows.RoutedEventHandler(this.dom_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ahojda = ((System.Windows.Controls.Frame)(target));
            return;
            case 5:
            this.pr_let = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\OvladaciOkno.xaml"
            this.pr_let.Click += new System.Windows.RoutedEventHandler(this.pr);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pr_pas = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\OvladaciOkno.xaml"
            this.pr_pas.Click += new System.Windows.RoutedEventHandler(this.pasa_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

