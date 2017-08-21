﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using MMI.Facility.WPFInfrastructure.Behaviors;
using MMI.Facility.WPFInfrastructure.Regions;
using Subway.ShenZhenLine7.Models;

namespace Subway.ShenZhenLine7.Bootstrapper
{
    /// <summary>
    /// 深圳七号线 启动加载器
    /// </summary>
    public class ShenZhenLine7Bootstrapper : MefBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject"/>, the
        ///             <see cref="T:Microsoft.Practices.Prism.Bootstrapper"/> will attach the default <seealso cref="T:Microsoft.Practices.Prism.Regions.IRegionManager"/> of
        ///             the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty"/> attached property
        ///             in order to be able to add regions by using the <seealso cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty"/>
        ///             attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            GlobalParam.Instance.Initialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config"),Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Subway.ShenZhenLine7.车辆屏", "config"));

            return new MainWindow();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        /// <remarks>
        /// The base implementation ensures the shell is composed in the container.
        /// </remarks>
        protected override void InitializeShell()
        {
            var win = Shell as Window;

            if (win == null)
            {
                return;
            }

            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Application.Current.MainWindow = win;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the <see cref="P:Microsoft.Practices.Prism.MefExtensions.MefBootstrapper.AggregateCatalog"/> used by MEF.
        /// </summary>
        /// <remarks>
        /// The base implementation does nothing.
        /// </remarks>
        protected override void ConfigureAggregateCatalog()
        {
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "*.dll"));
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "*.exe"));
        }

        /// <summary>
        /// Creates the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog"/> used by Prism.
        /// </summary>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
        /// <summary>
        /// Configures the default region adapter mappings to use in the application, in order
        /// to adapt UI controls defined in XAML to use a region and register it automatically.
        /// May be overwritten in a derived class to add specific mappings required by the application.
        /// </summary>
        /// <returns>The <see cref="T:Microsoft.Practices.Prism.Regions.RegionAdapterMappings" /> instance containing all the mappings.</returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mapping = base.ConfigureRegionAdapterMappings();

            if (mapping != null && ServiceLocator.Current.GetInstance<IRegionBehaviorFactory>() != null)
            {
                mapping.RegisterMapping(typeof(Border), ServiceLocator.Current.GetInstance<BorderControlRegionAdapter>());
            }

            return mapping;
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory"/>.
        ///             This will be the list of default behaviors that will be added to a region.
        /// </summary>
        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();

            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));

            return factory;
        }
    }
}