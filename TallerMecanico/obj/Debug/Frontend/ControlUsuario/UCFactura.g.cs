﻿#pragma checksum "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "635DE80478EC6F079D1236571170F6A0489DD2231EA6F5F3220A5E50159D9D88"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
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
using TallerMecanico.Frontend.ControlUsuario;


namespace TallerMecanico.Frontend.ControlUsuario {
    
    
    /// <summary>
    /// UCFactura
    /// </summary>
    public partial class UCFactura : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroId;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FiltroFechaRecepcion;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroCliente;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroImporte;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroConcepto;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnQuitarFiltros;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgListaFacturas;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem nItemEditar;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem nItemBorrar;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgId;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgFechaEmision;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn dgCliente;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn dgImporte;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgConcepto;
        
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
            System.Uri resourceLocater = new System.Uri("/TallerMecanico;component/frontend/controlusuario/ucfactura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
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
            this.FiltroId = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.FiltroId.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroId_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FiltroFechaRecepcion = ((System.Windows.Controls.DatePicker)(target));
            
            #line 28 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.FiltroFechaRecepcion.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.FiltroFechaEmision_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FiltroCliente = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.FiltroCliente.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroCliente_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FiltroImporte = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.FiltroImporte.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroImporte_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FiltroConcepto = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.FiltroConcepto.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroConcepto_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnQuitarFiltros = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.BtnQuitarFiltros.Click += new System.Windows.RoutedEventHandler(this.BtnQuitarFiltros_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgListaFacturas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.nItemEditar = ((System.Windows.Controls.MenuItem)(target));
            
            #line 46 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.nItemEditar.Click += new System.Windows.RoutedEventHandler(this.nItemEditar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.nItemBorrar = ((System.Windows.Controls.MenuItem)(target));
            
            #line 52 "..\..\..\..\Frontend\ControlUsuario\UCFactura.xaml"
            this.nItemBorrar.Click += new System.Windows.RoutedEventHandler(this.nItemBorrar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dgId = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.dgFechaEmision = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.dgCliente = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 13:
            this.dgImporte = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 14:
            this.dgConcepto = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

