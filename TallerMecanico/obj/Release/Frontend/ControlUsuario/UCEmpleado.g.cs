﻿#pragma checksum "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F981D9E7BC3D969149E0EC5AED4DEB408489AD55253D6167BC8D73F4147190B5"
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
    /// UCEmpleado
    /// </summary>
    public partial class UCEmpleado : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroNombre;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroUsuario;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroContrasenya;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiltroRol;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnQuitarFiltros;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgListaEmpleados;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem nItemEditar;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem nItemBorrar;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgId;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn dgNombre;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgUsuario;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgContrasenya;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dgRol;
        
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
            System.Uri resourceLocater = new System.Uri("/TallerMecanico;component/frontend/controlusuario/ucempleado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
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
            
            #line 24 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.FiltroId.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroId_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FiltroNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.FiltroNombre.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroNombre_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FiltroUsuario = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.FiltroUsuario.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroUsuario_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FiltroContrasenya = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.FiltroContrasenya.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroContrasenya_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FiltroRol = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.FiltroRol.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FiltroRol_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnQuitarFiltros = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.BtnQuitarFiltros.Click += new System.Windows.RoutedEventHandler(this.BtnQuitarFiltros_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgListaEmpleados = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.nItemEditar = ((System.Windows.Controls.MenuItem)(target));
            
            #line 44 "..\..\..\..\Frontend\ControlUsuario\UCEmpleado.xaml"
            this.nItemEditar.Click += new System.Windows.RoutedEventHandler(this.nItemEditar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.nItemBorrar = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 10:
            this.dgId = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.dgNombre = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 12:
            this.dgUsuario = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 13:
            this.dgContrasenya = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 14:
            this.dgRol = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

