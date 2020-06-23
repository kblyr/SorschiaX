﻿using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaException : Exception
    {
        public bool IsMessageViewable { get; }

        public SorschiaException(bool isMessageViewable = default)
        {
            IsMessageViewable = isMessageViewable;
        }

        public SorschiaException(string message, bool isMessageViewable = default) : base(message)
        {
            IsMessageViewable = isMessageViewable;
        }

        public SorschiaException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException)
        {
            IsMessageViewable = isMessageViewable;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context)
        {
            IsMessageViewable = isMessageViewable;
        }

        public static SorschiaException RepositoryIsNull<TRepository>() => new SorschiaException($"Repository of type {typeof(TRepository).FullName} is null");
        public static SorschiaException DependencySettingsIsNull<TDependencySettings>() => new SorschiaException($"Dependency settings of type {typeof(TDependencySettings).FullName} is null");
    }
}
