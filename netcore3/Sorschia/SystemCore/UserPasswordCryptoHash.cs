﻿using Sorschia.Security;

namespace Sorschia.SystemCore
{
    internal sealed class UserPasswordCryptoHash : IUserPasswordCryptoHash
    {
        private readonly CryptoHash _cryptoHash;

        public UserPasswordCryptoHash(CryptoHash cryptoHash)
        {
            _cryptoHash = cryptoHash;
        }

        public string ComputeHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return null;

            return _cryptoHash.ComputeSha512(password);
        }
    }
}
