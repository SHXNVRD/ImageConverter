﻿#pragma checksum "D:\dotnet\repos\ImageConverter\ImageConverter\Views\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3FD9B76604AB96DCB82ED26D3DD2543C730EEC37F0492F1F3F3530E769800AAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageConverter
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Boolean value)
            {
                obj.IsBackEnabled = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Microsoft_UI_Xaml_AdaptiveTrigger_MinWindowWidth(global::Microsoft.UI.Xaml.AdaptiveTrigger obj, global::System.Double value)
            {
                obj.MinWindowWidth = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainWindow_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IMainWindow_Bindings
        {
            private global::ImageConverter.MainWindow dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.NavigationView obj4;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj5;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj6;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj10;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj11;
            private global::Microsoft.UI.Xaml.AdaptiveTrigger obj14;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4IsBackEnabledDisabled = false;
            private static bool isobj4SelectedItemDisabled = false;
            private static bool isobj5CommandDisabled = false;
            private static bool isobj6CommandDisabled = false;
            private static bool isobj10CommandDisabled = false;
            private static bool isobj11CommandDisabled = false;
            private static bool isobj14MinWindowWidthDisabled = false;

            private MainWindow_obj1_BindingsTracking bindingsTracking;

            public MainWindow_obj1_Bindings()
            {
                this.bindingsTracking = new MainWindow_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 51 && columnNumber == 7)
                {
                    isobj4IsBackEnabledDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 7)
                {
                    isobj4SelectedItemDisabled = true;
                }
                else if (lineNumber == 60 && columnNumber == 29)
                {
                    isobj5CommandDisabled = true;
                }
                else if (lineNumber == 57 && columnNumber == 29)
                {
                    isobj6CommandDisabled = true;
                }
                else if (lineNumber == 105 && columnNumber == 31)
                {
                    isobj10CommandDisabled = true;
                }
                else if (lineNumber == 102 && columnNumber == 31)
                {
                    isobj11CommandDisabled = true;
                }
                else if (lineNumber == 116 && columnNumber == 24)
                {
                    isobj14MinWindowWidthDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // Views\MainWindow.xaml line 48
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                        break;
                    case 5: // Views\MainWindow.xaml line 60
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction>(target);
                        break;
                    case 6: // Views\MainWindow.xaml line 57
                        this.obj6 = global::WinRT.CastExtensions.As<global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction>(target);
                        break;
                    case 10: // Views\MainWindow.xaml line 105
                        this.obj10 = global::WinRT.CastExtensions.As<global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction>(target);
                        break;
                    case 11: // Views\MainWindow.xaml line 102
                        this.obj11 = global::WinRT.CastExtensions.As<global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction>(target);
                        break;
                    case 14: // Views\MainWindow.xaml line 116
                        this.obj14 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.AdaptiveTrigger>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMainWindow_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::ImageConverter.MainWindow>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::ImageConverter.MainWindow obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_NavViewCompactModeThresholdWidth(obj.NavViewCompactModeThresholdWidth, phase);
                    }
                }
            }
            private void Update_ViewModel(global::ImageConverter.ViewModels.MainViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_BackButtonEnabled(obj.BackButtonEnabled, phase);
                        this.Update_ViewModel_SelectedNavigationItem(obj.SelectedNavigationItem, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_BackRequestedCommand(obj.BackRequestedCommand, phase);
                        this.Update_ViewModel_ItemInvokedCommand(obj.ItemInvokedCommand, phase);
                        this.Update_ViewModel_NavigatedCommand(obj.NavigatedCommand, phase);
                        this.Update_ViewModel_NavigationFailedCommand(obj.NavigationFailedCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_BackButtonEnabled(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\MainWindow.xaml line 48
                    if (!isobj4IsBackEnabledDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(this.obj4, obj);
                    }
                }
            }
            private void Update_ViewModel_SelectedNavigationItem(global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\MainWindow.xaml line 48
                    if (!isobj4SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(this.obj4, obj, null);
                    }
                }
            }
            private void Update_ViewModel_BackRequestedCommand(global::CommunityToolkit.Mvvm.Input.IRelayCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainWindow.xaml line 60
                    if (!isobj5CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj5, obj, null);
                    }
                }
            }
            private void Update_ViewModel_ItemInvokedCommand(global::CommunityToolkit.Mvvm.Input.IRelayCommand<global::Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainWindow.xaml line 57
                    if (!isobj6CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj6, obj, null);
                    }
                }
            }
            private void Update_ViewModel_NavigatedCommand(global::CommunityToolkit.Mvvm.Input.IRelayCommand<global::Microsoft.UI.Xaml.Navigation.NavigationEventArgs> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainWindow.xaml line 105
                    if (!isobj10CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj10, obj, null);
                    }
                }
            }
            private void Update_ViewModel_NavigationFailedCommand(global::CommunityToolkit.Mvvm.Input.IRelayCommand<global::Microsoft.UI.Xaml.Navigation.NavigationFailedEventArgs> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainWindow.xaml line 102
                    if (!isobj11CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj11, obj, null);
                    }
                }
            }
            private void Update_NavViewCompactModeThresholdWidth(global::System.Double obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\MainWindow.xaml line 116
                    if (!isobj14MinWindowWidthDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_AdaptiveTrigger_MinWindowWidth(this.obj14, obj);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class MainWindow_obj1_BindingsTracking
            {
                private global::System.WeakReference<MainWindow_obj1_Bindings> weakRefToBindingObj; 

                public MainWindow_obj1_BindingsTracking(MainWindow_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<MainWindow_obj1_Bindings>(obj);
                }

                public MainWindow_obj1_Bindings TryGetBindingObject()
                {
                    MainWindow_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    MainWindow_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::ImageConverter.ViewModels.MainViewModel obj = sender as global::ImageConverter.ViewModels.MainViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_BackButtonEnabled(obj.BackButtonEnabled, DATA_CHANGED);
                                bindings.Update_ViewModel_SelectedNavigationItem(obj.SelectedNavigationItem, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "BackButtonEnabled":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_BackButtonEnabled(obj.BackButtonEnabled, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SelectedNavigationItem":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectedNavigationItem(obj.SelectedNavigationItem, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::ImageConverter.ViewModels.MainViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::ImageConverter.ViewModels.MainViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\MainWindow.xaml line 2
                {
                    global::Microsoft.UI.Xaml.Window element1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Window>(target);
                    ((global::Microsoft.UI.Xaml.Window)element1).Activated += this.MainWindow_Activated;
                }
                break;
            case 2: // Views\MainWindow.xaml line 14
                {
                    this.RootGrid = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // Views\MainWindow.xaml line 22
                {
                    this.AppTitleBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 4: // Views\MainWindow.xaml line 48
                {
                    this.NavView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                }
                break;
            case 7: // Views\MainWindow.xaml line 70
                {
                    this.ImageConvertHeader = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationViewItemHeader>(target);
                }
                break;
            case 8: // Views\MainWindow.xaml line 93
                {
                    this.NavViewSearchBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AutoSuggestBox>(target);
                }
                break;
            case 9: // Views\MainWindow.xaml line 98
                {
                    this.ContentFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            case 12: // Views\MainWindow.xaml line 33
                {
                    this.TitleBarIcon = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
                }
                break;
            case 13: // Views\MainWindow.xaml line 39
                {
                    this.TitleBarTextBlock = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\MainWindow.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Window element1 = (global::Microsoft.UI.Xaml.Window)target;
                    MainWindow_obj1_Bindings bindings = new MainWindow_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Activated += bindings.Activated;
                }
                break;
            }
            return returnValue;
        }
    }
}

