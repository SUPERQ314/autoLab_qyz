﻿#pragma checksum "..\..\Dispense.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5DA82F6F096B2BDECE0D2346C6BB5D861C78D35F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TrialEdit;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace TrialEdit {
    
    
    /// <summary>
    /// Dispense
    /// </summary>
    public partial class Dispense : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Dispense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WorkStationC;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Dispense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WorkStationR;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Dispense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TipTC;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Dispense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TipC;
        
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
            System.Uri resourceLocater = new System.Uri("/TrialEdit;component/dispense.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Dispense.xaml"
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
            
            #line 12 "..\..\Dispense.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CloseCommandHandler);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WorkStationC = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\Dispense.xaml"
            this.WorkStationC.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WorkStationCChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.WorkStationR = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\Dispense.xaml"
            this.WorkStationR.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WorkStationRChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TipTC = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\Dispense.xaml"
            this.TipTC.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TipTypeChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TipC = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\Dispense.xaml"
            this.TipC.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TipCChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

