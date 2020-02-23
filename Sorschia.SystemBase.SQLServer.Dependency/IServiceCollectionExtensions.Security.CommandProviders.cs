﻿using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemBase.Security.CommandProviders;

namespace Sorschia.SystemBase
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection InternalAddSecurityCommandProviders(this IServiceCollection instance)
        {
            #region Application
            instance
                .InternalAddProvider<DeleteApplicationCommandProvider>()
                .InternalAddProvider<GetApplicationCommandProvider>()
                .InternalAddProvider<GetApplicationListCommandProvider>()
                .InternalAddProvider<RemoveApplicationFromPlatformCommandProvider>()
                .InternalAddProvider<SaveApplicationCommandProvider>();
            #endregion

            #region ApplicationPlatform
            instance
                .InternalAddProvider<DeleteApplicationPlatformCommandProvider>()
                .InternalAddProvider<GetApplicationPlatformCommandProvider>()
                .InternalAddProvider<GetApplicationPlatformListCommandProvider>()
                .InternalAddProvider<SaveApplicationPlatformCommandProvider>();
            #endregion

            #region Module
            instance
                .InternalAddProvider<DeleteModuleCommandProvider>()
                .InternalAddProvider<GetModuleCommandProvider>()
                .InternalAddProvider<GetModuleListCommandProvider>()
                .InternalAddProvider<RemoveModuleFromApplicationCommandProvider>()
                .InternalAddProvider<SaveModuleCommandProvider>();
            #endregion

            #region Permission
            instance
                .InternalAddProvider<DeletePermissionCommandProvider>()
                .InternalAddProvider<GetPermissionCommandProvider>()
                .InternalAddProvider<SavePermissionCommandProvider>();
            #endregion

            #region User
            instance
                .InternalAddProvider<DeleteUserCommandProvider>()
                .InternalAddProvider<GetUserCommandProvider>()
                .InternalAddProvider<SaveUserCommandProvider>();
            #endregion

            #region UserApplication
            instance
                .InternalAddProvider<DeleteUserApplicationCommandProvider>()
                .InternalAddProvider<SaveUserApplicationCommandProvider>();
            #endregion

            #region UserModule
            instance
                .InternalAddProvider<DeleteUserModuleCommandProvider>()
                .InternalAddProvider<SaveUserModuleCommandProvider>();
            #endregion

            #region UserPermission
            instance
                .InternalAddProvider<DeleteUserPermissionCommandProvider>()
                .InternalAddProvider<SaveUserPermissionCommandProvider>();
            #endregion

            return instance;
        }
    }
}